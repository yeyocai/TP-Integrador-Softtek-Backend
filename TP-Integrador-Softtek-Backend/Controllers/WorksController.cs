using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Entities;
using TP_Integrador_Softtek_Backend.Services;

namespace TP_Integrador_Softtek_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtiene todos los trabajos que no tengan baja logica
        /// </summary>
        /// <returns>Todos los trabajos que cumplen la condicion</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Work>>> GetAll()
        {
            var works = await _unitOfWork.WorkRepository.GetAll();
            return Ok(works);
        }


        /// <summary>
        /// Obtiene un trabajo segun su codigo de trabajo
        /// </summary>
        /// <param name="id">Codigo de trabajo</param>
        /// <returns>El trabajo con ese codigo o un mensaje si no existe</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var work = await _unitOfWork.WorkRepository.GetById(id);

            if (work == null)
            {
                return BadRequest("El trabajo no existe");
            }

            return Ok(work);
        }


        /// <summary>
        /// Registra un nuevo trabajo
        /// </summary>
        /// <param name="dto">Campos del nuevo trabajo</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(WorkDto dto)
        {
            var work = new Work(dto);
            await _unitOfWork.WorkRepository.Insert(work);
            await _unitOfWork.Complete();
            return Ok("Trabajo creado");
        }


        /// <summary>
        /// Actualiza los campos de un trabajo
        /// </summary>
        /// <param name="id">Codigo del trabajo</param>
        /// <param name="dto">Nuevos campos del trabajo</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, WorkDto dto)
        {
            var result = await _unitOfWork.WorkRepository.Update(new Work(dto, id));

            if (result == false)
            {
                return BadRequest("El trabajo no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Trabajo actualizado");
        }


        /// <summary>
        /// Elimina de manera logica un trabajo
        /// </summary>
        /// <param name="id">Codigo del trabajo</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.WorkRepository.Delete(id);

            if (result == false)
            {
                return BadRequest("El trabajo no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Trabajo eliminado");
        }
    }
}
