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


namespace MyFitTimer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopwatchTrackerController : ControllerBase
    {
        private IStopwatchTrackerService topwatchTrackerModel;
        private readonly ITimeKeeperDataService _timeKeeperDataService;

        public StopwatchTracker ret { get; set; } = new StopwatchTracker();
        public TimeKeeper ret2 { get; set; } = new TimeKeeper();

        public StopwatchTrackerController(IStopwatchTrackerService stopwatchTrackerModel, ITimeKeeperDataService timeKeeperDataService)
        {
            topwatchTrackerModel = stopwatchTrackerModel;
            _timeKeeperDataService = timeKeeperDataService;
        }

        [HttpGet("start")]
        public async Task<IActionResult> StartWatch()
        {
            topwatchTrackerModel.Start();

            return Ok();
        }

        [HttpGet("elapsed")]
        public async Task<IActionResult> GetElaspsed()
        {
            ret.Elapsed = topwatchTrackerModel.GetElapsed();
            return Ok(ret);
        }

        [HttpGet("stop")]
        public async Task<IActionResult> Stop()
        {
            topwatchTrackerModel.Stop();
            ret2.Time = ret.Elapsed;
            await _timeKeeperDataService.CreateTimeKeepers(ret2);

            return Ok();
        }
    }
}
