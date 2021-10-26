﻿using BLL.Services.Interface;
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
    public class ChiefController : ControllerBase
    {
        private readonly IChiefService ChiefService;
        private readonly ILogger<ChiefController> Logger;

        public ChiefController(IChiefService chiefService, ILogger<ChiefController> logger)
        {
            ChiefService = chiefService;
            Logger = logger;
        }

        [HttpPost]
        public IActionResult CreateUser(ChiefViewModel userModel)
        {
            ChiefService.Create(userModel);
            return Ok(userModel);
        }
    }
}
