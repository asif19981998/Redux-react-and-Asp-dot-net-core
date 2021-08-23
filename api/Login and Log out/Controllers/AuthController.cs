using Login_and_Log_out.Data;
using Login_and_Log_out.Dtos;
using Login_and_Log_out.Helpers;
using Login_and_Log_out.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_and_Log_out.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository,JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
                
            };
            _repository.Create(user);
            return Ok("Success");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if (user == null) return BadRequest(new { message = "Invalid Email" });
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Password" });
            };
            var jwt = _jwtService.Generate(user.Id);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
        });
            return Ok(user);

        }
    
       [HttpGet("user")]
       public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _repository.GetById(userId);
                return Ok(user);
            }
            catch(Exception _)
            {
                return Unauthorized();
            }
           
        }
       [HttpPost("logout")]
       public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new {
                message="successfully Logout"
            });
        }
    
    }
}
