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
    public class EventTemplateController : ControllerBase
    {
        private readonly IEventTemplateService _eventTemplateService;

        public EventTemplateController(IEventTemplateService eventTemplateService)
        {
            _eventTemplateService = eventTemplateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventTemplate(EventTemplateCreateModel eventTemplateModel)
        {
            var viewModel = await _eventTemplateService.Create(eventTemplateModel);
            return Ok(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _eventTemplateService.GetAll();
            return Ok(result);
        }
    }
}
