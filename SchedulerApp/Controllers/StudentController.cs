using BLL.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchedulerApp.Controllers.Validation;
using SchedulerViewModels;
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
            try
            {
                UserValidation.ValidateUser(studentModel, ModelState);
                if (ModelState.IsValid)
                {
                    StudentService.Create(studentModel);
                    return Ok(studentModel);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = StudentService.GetAll();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(StudentViewModel studentModel)
        {
            try
            {
                UserValidation.ValidateUser(studentModel, ModelState);
                if (ModelState.IsValid)
                {
                    StudentService.Update(studentModel);
                    return Ok(studentModel);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
