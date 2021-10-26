using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService StudentService;
        private readonly ILogger<StudentController> Logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            StudentService = studentService;
            Logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser(StudentViewModel userModel)
        {
            StudentService.Create(userModel);
            return Ok(userModel);
        }
    }
}
