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
    public class WeeklyEventController : ControllerBase
    {
        private readonly IWeeklyEventService _WeeklyEventService;

        public WeeklyEventController(IWeeklyEventService WeeklyEventService)
        {
            _WeeklyEventService = WeeklyEventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeeklyEvent(WeeklyEventCreateModel WeeklyEventModel)
        {
            var viewModel = await _WeeklyEventService.Create(WeeklyEventModel);
            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _WeeklyEventService.GetAll();
            return Ok(result);
        }
    }
}
