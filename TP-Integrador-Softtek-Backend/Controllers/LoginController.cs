using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Integrador_Softtek_Backend.DTOs;
using TP_Integrador_Softtek_Backend.Helper;
using TP_Integrador_Softtek_Backend.Services;

namespace TP_Integrador_Softtek_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }


        [HttpPost] 
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var userCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(dto);

            if (userCredentials == null)
            {
                return Unauthorized("Las credenciales son incorrectas");
            }

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UserLoginDto()
            {
                Email = userCredentials.Email,
                Name = userCredentials.Name,
                Token = token
            };

            return Ok(user);
        }

    }
}
