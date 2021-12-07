using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SingleEventController : ControllerBase
    {
        private readonly ISingleEventService _singleEventService;

        public SingleEventController(ISingleEventService singleEventService)
        {
            _singleEventService = singleEventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSingleEvent(SingleEventCreateModel singleEventModel)
        {
            var viewModel = await _singleEventService.Create(singleEventModel);
            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _singleEventService.GetAll();
            return Ok(result);
        }
    }
}
