using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ChiefController : ControllerBase
    {
        private readonly IChiefService _chiefService;

        public ChiefController(IChiefService chiefService)
        {
            _chiefService = chiefService;
        }

        [HttpPost]
        public IActionResult CreateUser(ChiefCreateModel userModel)
        {
            _chiefService.Create(userModel);
            return Ok(userModel);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _chiefService.Get(id);
            return Ok(result);
        }
    }
}
