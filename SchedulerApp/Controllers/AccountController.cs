using BLL.Services.Interface;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountController> Logger;

        public AccountController(IStudentService studentService, ILogger<AccountController> logger)
        {
            StudentService = studentService;
            Logger = logger;
        }

        [HttpPost]
        public IActionResult Authentificate(string username, string password)
        {
            Logger.LogInformation("Authentificate: validation...");
            UserValidation.ValidateNameAndPassword(username, password, ModelState);
            if (!ModelState.IsValid)
            {
                Logger.LogError("Authentificate: Input not valid.");
                return BadRequest(ModelState);
            }
            StudentViewModel student;
            try
            {
                Logger.LogInformation("Authentificate: get user model...");
                student = StudentService.GetByNameAndPassword(username, password);
            }
            catch(ItemNotFoundException ex)
            {
                Logger.LogError("Authentificate: Name or password doesn't match.");
                return BadRequest(new { errorText = "Invalid username or password." });
            }
            catch(Exception ex)
            {
                Logger.LogError("Authentificate: " + ex.Message);
                return BadRequest(new { ex.Message });
            }


            Logger.LogInformation("Authentificate: create token...");
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

            Logger.LogInformation("Authentificate: success.");
            return Ok(response);
        }
    }
}
