using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Server.Data;
using MyFitTimer.Shared;
using MyFitTimer.Server.Services;
using MyFitTimer.Server.Models;

namespace MyFitTimer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopwatchTrackerController : ControllerBase
    {
        private readonly StopwatchTracker _stopwatchTracker;

        public StopwatchTrackerController(StopwatchTracker stopwatchTracker)
        {
            _stopwatchTracker = stopwatchTracker;
        }

        [HttpHead]
        public async Task<IActionResult> StartWatch()
        {
            _stopwatchTracker.Start();

            return Ok();
        }
    }
}
