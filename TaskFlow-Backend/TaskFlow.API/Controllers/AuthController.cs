using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskFlow.API.Dtos.User;
using TaskFlow.API.Interfaces;
using TaskFlow.API.Models;
using TaskFlow.API.Services;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly TokenService _tokenservice;

        public AuthController(IAuthRepository repo, TokenService tokenService)
        {
            _repo = repo;
            _tokenservice = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Resister(RegisterDTO dto)
        {
            if(await _repo.UserExists(dto.Username)) 
                return BadRequest("User is already exist");

            var user = new User {
                    Username = dto.Username,
                    Role = dto.Role 
                };
            await _repo.Register(user, dto.Password);
            var token = _tokenservice.CreateToken(user);

            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO dto)
        {
            var user = await _repo.Login(dto.Username, dto.Password);

            if(user == null) return Unauthorized("Bad credentials");
            var token = _tokenservice.CreateToken(user);
            return Ok(token);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("Bienvenue Admin !");
        }

        [Authorize(Roles = "User")]
        [HttpGet("user-area")]
        public IActionResult UserOnlyEndpoint()
        {
            return Ok("Bienvenue Utilisateur !");
        }

    }
}