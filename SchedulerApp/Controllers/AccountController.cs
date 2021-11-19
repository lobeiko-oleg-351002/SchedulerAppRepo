using BLL.Services.Interface;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IStudentService _studentService;

        public AccountController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentificate(string username, string password)
        {
            StudentViewModel student = await _studentService.GetByNameAndPassword(username, password);
            var userToken = AuthOptions.CreateUserToken(student);
            return Ok(userToken);
        }
    }
}
