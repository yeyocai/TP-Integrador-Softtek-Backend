using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Entities;
using TP_Integrador_Softtek_Backend.Services;
using static TP_Integrador_Softtek_Backend.Entities.Project;

namespace TP_Integrador_Softtek_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtiene todos los proyectos que no tengan baja logica
        /// </summary>
        /// <returns>Todos los proyectos que cumplen la condicion</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAll()
        {
            var projects = await _unitOfWork.ProjectRepository.GetAll();
            return Ok(projects);
        }


        /// <summary>
        /// Obtiene todos los proyectos segun su estado
        /// </summary>
        /// <param name="state">Estado</param>
        /// <returns>Todos los proyectos que tienen ese estado</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetByState")]
        public async Task<ActionResult<IEnumerable<Project>>> GetByState(int state)
        {
            var projects = await _unitOfWork.ProjectRepository.GetByState(state);
            return Ok(projects);
        }


        /// <summary>
        /// Obtiene un proyecto segun su codigo de proyecto
        /// </summary>
        /// <param name="id">Codigo de proyecto</param>
        /// <returns>El proyecto con ese codigo o un mensaje si no existe</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(id);

            if (project == null)
            {
                return BadRequest("El proyecto no existe");
            }

            return Ok(project);
        }


        /// <summary>
        /// Registra un nuevo proyecto
        /// </summary>
        /// <param name="dto">Campos del nuevo proyecto</param>
        /// <returns>Un mensaje</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ProjectDto dto)
        {
            var project = new Project(dto);
            await _unitOfWork.ProjectRepository.Insert(project);
            await _unitOfWork.Complete();
            return Ok("Proyecto creado");
        }


        /// <summary>
        /// Actualiza los campos de un proyecto
        /// </summary>
        /// <param name="id">Codigo del proyecto</param>
        /// <param name="dto">Nuevos campos del proyecto</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ProjectDto dto)
        {
            var result = await _unitOfWork.ProjectRepository.Update(new Project(dto, id));

            if (result == false)
            {
                return BadRequest("El proyecto no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Proyecto actualizado");
        }


        /// <summary>
        /// Elimina de manera logica un proyecto
        /// </summary>
        /// <param name="id">Codigo del proyecto</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProjectRepository.Delete(id);

            if (result == false)
            {
                return BadRequest("El proyecto no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Proyecto eliminado");
        }
    }
}
