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
        private readonly StopwatchTrackerModel _stopwatchTrackerModel;

        private StopwatchTracker ret { get; set; } = new StopwatchTracker()
        {
            Start = 0,
            Stop = 0,
            Elapsed = 0
        };

        public StopwatchTrackerController(StopwatchTrackerModel stopwatchTrackerModel)
        {
            _stopwatchTrackerModel = stopwatchTrackerModel;
        }

        [HttpGet]
        public async Task<IActionResult> StartWatch()
        {
            _stopwatchTrackerModel.Start();

            return Ok(await _stopwatchTrackerModel.GetElapsed());
        }

        /*[HttpGet("elapsed")]
        public async Task<IActionResult> GetElaspsed()
        {            
            return Ok(await _stopwatchTrackerModel.GetElapsed());
        }

        [HttpGet("stop")]
        public async Task<IActionResult> Stop()
        {
            _stopwatchTrackerModel.Stop();


            return Ok(await _stopwatchTrackerModel.GetElapsed());
        }*/
    }
}
