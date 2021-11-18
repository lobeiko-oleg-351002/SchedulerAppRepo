using BLL.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult CreateUser(StudentCreateModel studentModel)
        {
            _studentService.Create(studentModel);
            return Ok(studentModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _studentService.GetAll();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(StudentCreateModel studentModel)
        {
            _studentService.Update(studentModel);
            return Ok(studentModel);
        }
    }
}
