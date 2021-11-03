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
        public IActionResult CreateUser(StudentViewModel studentModel)
        {
            StudentService.Create(studentModel);
            return Ok(studentModel);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = StudentService.GetAll();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateUser(StudentViewModel studentModel)
        {
            StudentService.Update(studentModel);
            return new OkResult();
        }
    }
}
