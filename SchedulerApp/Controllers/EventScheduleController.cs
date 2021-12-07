using BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using SchedulerViewModels;
using SchedulerViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventScheduleController : ControllerBase
    {
        private readonly ISingleEventService _singleEventService;
        private readonly IWeeklyEventService _weeklyEventService;

        public EventScheduleController(ISingleEventService singleEventService, IWeeklyEventService weeklyEventService)
        {
            _singleEventService = singleEventService;
            _weeklyEventService = weeklyEventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByChiefIdAndDateRange(Guid chiefId, DateTimeRange range)
        {
            var singleEvents = ((IEventFilter<SingleEventViewModel>)_singleEventService).GetByChiefIdAndDateTimeRange(chiefId, range);
            var weeklyEvents = ((IEventFilter<WeeklyEventViewModel>)_weeklyEventService).GetByChiefIdAndDateTimeRange(chiefId, range);
            return Ok(singleEvents);
        }
    }
}
