using BLL.Services.Interface;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchedulerApp.AuthorizationTokens;
using SchedulerApp.Controllers.Validation;
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
            UserValidation.ValidateNameAndPassword(username, password, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            StudentViewModel student;
            try
            {
                student = StudentService.GetByNameAndPassword(username, password);
            }
            catch(ItemNotFoundException ex)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = AuthOptions.CreateClaimsIdentity(student),
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
