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


        /// <summary>
        /// Obtiene todos los servicios que se encuentren activos
        /// </summary>
        /// <returns>Todos los servicios que cumplen la condicion</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Service>>> GetAll()
        {
            var services = await _unitOfWork.ServiceRepository.GetAll();
            return Ok(services);
        }


        /// <summary>
        /// Obtiene un servicio segun su codigo de servicio
        /// </summary>
        /// <param name="id">Codigo de servicio</param>
        /// <returns>El servicio con ese codigo o un mensaje si no existe</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var service = await _unitOfWork.ServiceRepository.GetById(id);

            if (service == null)
            {
                return BadRequest("El servicio no existe");
            }

            return Ok(service);
        }


        /// <summary>
        /// Registra un nuevo servicio
        /// </summary>
        /// <param name="dto">Campos del nuevo servicio</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ServiceDto dto)
        {
            var service = new Service(dto);
            await _unitOfWork.ServiceRepository.Insert(service);
            await _unitOfWork.Complete();
            return Ok("Servicio creado");
        }


        /// <summary>
        /// Actualiza los campos de un servicio
        /// </summary>
        /// <param name="id">Codigo del servicio</param>
        /// <param name="dto">Nuevos campos del servicio</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, ServiceDto dto)
        {
            var result = await _unitOfWork.ServiceRepository.Update(new Service(dto, id));

            if (result == false)
            {
                return BadRequest("El servicio no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Servicio actualizado");
        }


        /// <summary>
        /// Elimina de manera logica un servicio, poniendolo como inactivo
        /// </summary>
        /// <param name="id">Codigo del servicio</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.ServiceRepository.Delete(id);

            if (result == false)
            {
                return BadRequest("El servicio no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Servicio eliminado");
        }
    }
}
