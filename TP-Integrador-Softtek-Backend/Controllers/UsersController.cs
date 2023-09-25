using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Entities;
using TP_Integrador_Softtek_Backend.Helper;
using TP_Integrador_Softtek_Backend.Services;

namespace TP_Integrador_Softtek_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtiene todos los usuarios que no tengan baja logica
        /// </summary>
        /// <returns>Todos los usuarios que cumplen la condicion</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            return Ok(users);
        }


        /// <summary>
        /// Obtiene un usuario segun su codigo de usuario
        /// </summary>
        /// <param name="id">Codigo de usuario</param>
        /// <returns>El usuario con ese codigo o un mensaje si no existe</returns>
        [Authorize(Policy = "AdministradorConsultor")]
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            if(user == null)
            {
                return BadRequest("El usuario no existe");
            }

            return Ok(user);
        }


        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        /// <param name="dto">Campos del nuevo usuario</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            PasswordEncryptHelper.EncryptPassword(dto.Password);
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();
            return Ok("Usuario creado");
        }


        /// <summary>
        /// Actualiza los campos de un usuario
        /// </summary>
        /// <param name="id">Codigo del usuario</param>
        /// <param name="dto">Nuevos campos del usuario</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, RegisterDto dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));

            if (result == false)
            {
                return BadRequest("El usuario no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Usuario actualizado");
        }


        /// <summary>
        /// Elimina de manera logica un usuario
        /// </summary>
        /// <param name="id">Codigo del usuario</param>
        /// <returns>Un mensaje informativo</returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.Delete(id);

            if (result == false)
            {
                return BadRequest("El usuario no existe");
            }

            await _unitOfWork.Complete();
            return Ok("Usuario eliminado");
        }
    }
}
