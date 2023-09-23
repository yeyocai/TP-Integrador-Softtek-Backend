﻿using Microsoft.AspNetCore.Authorization;
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

    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll(); 
            return Ok(users);
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            if(user == null)
            {
                return BadRequest(false);
            }

            return Ok(user);
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, RegisterDto dto)
        {
            var result = await _unitOfWork.UserRepository.Update(new User(dto, id));
            await _unitOfWork.Complete();
            return Ok(true);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
