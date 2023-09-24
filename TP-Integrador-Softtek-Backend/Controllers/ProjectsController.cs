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
    [Authorize]

    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAll()
        {
            var Projects = await _unitOfWork.ProjectRepository.GetAll();
            return Ok(Projects);
        }


        [HttpGet]
        [Route("GetByState")]
        public async Task<ActionResult<IEnumerable<Project>>> GetByState(int state)
        {
            var Projects = await _unitOfWork.ProjectRepository.GetByState(state);
            return Ok(Projects);
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var Project = await _unitOfWork.ProjectRepository.GetById(id);

            if (Project == null)
            {
                return BadRequest(false);
            }

            return Ok(Project);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ProjectDto dto)
        {
            var Project = new Project(dto);
            await _unitOfWork.ProjectRepository.Insert(Project);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ProjectDto dto)
        {
            var result = await _unitOfWork.ProjectRepository.Update(new Project(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ProjectRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
