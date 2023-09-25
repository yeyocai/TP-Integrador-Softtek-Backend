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

    public class ServicesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            var services = await _unitOfWork.ServiceRepository.GetAll();
            return Ok(services);
        }


        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetById(id);

            if (service == null)
            {
                return BadRequest(false);
            }

            return Ok(service);
        }


        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ServiceDto dto)
        {
            var service = new Service(dto);
            await _unitOfWork.ServiceRepository.Insert(service);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [Authorize(Policy = "Administrador")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ServiceDto dto)
        {
            var result = await _unitOfWork.ServiceRepository.Update(new Service(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [Authorize(Policy = "Administrador")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
