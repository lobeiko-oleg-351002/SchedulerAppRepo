using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchedulerApp.AuthorizationTokens;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IStudentService StudentService;

        public AccountController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        [HttpPost]
        public IActionResult Authentificate(string username, string password)
        {
            StudentViewModel student = StudentService.GetByNameAndPassword(username, password);
            if (student == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"User"),
                    new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                    new Claim(ClaimTypes.Email, student.Email),
                    new Claim(ClaimTypes.Role, student.Role.Name),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var response = new
            {
                access_token = tokenHandler.WriteToken(token),
                username = student.Name
            };

            return Ok(response);
        }
    }
}
