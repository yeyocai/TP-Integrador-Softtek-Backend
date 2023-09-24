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
    [Authorize]

    public class WorksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Work>>> GetAll()
        {
            var works = await _unitOfWork.WorkRepository.GetAll();
            return Ok(works);
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var work = await _unitOfWork.WorkRepository.GetById(id);

            if (work == null)
            {
                return BadRequest(false);
            }

            return Ok(work);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(WorkDto dto)
        {
            var work = new Work(dto);
            await _unitOfWork.WorkRepository.Insert(work);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, WorkDto dto)
        {
            var result = await _unitOfWork.WorkRepository.Update(new Work(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.WorkRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
