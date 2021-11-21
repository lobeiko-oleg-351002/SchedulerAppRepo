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
        public async Task<IActionResult> CreateUser(ChiefCreateModel userModel)
        {
            var viewModel = await _chiefService.Create(userModel);
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _chiefService.Get(id);
            return Ok(result);
        }
    }
}
