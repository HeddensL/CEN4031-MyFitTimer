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
    public class StopwatcherController : ControllerBase
    {       
        private readonly ITimeKeeperDataService _timeKeeperDataService;

        public StopwatcherController(ITimeKeeperDataService timeKeeperDataService)
        {
            _timeKeeperDataService = timeKeeperDataService;
        }        

        [HttpGet]
        public async Task<IActionResult> GetLatestTime()
        {                     
            return Ok(await _timeKeeperDataService.GetLatestTimeKeepers());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTime(TimeKeeper time)
        {
            return Ok(await _timeKeeperDataService.CreateTimeKeepers(time));
        }
    }
}
