using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Server.Data;
using MyFitTimer.Shared;
using MyFitTimer.Server.Services;

namespace MyFitTimer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeKeeperController : ControllerBase
    {
        private readonly ITimeKeeperDataService _timeKeeperDataService;

        public TimeKeeperController(ITimeKeeperDataService timeKeeperDataService)
        {
            _timeKeeperDataService = timeKeeperDataService;
        }      

        [HttpGet]
        public async Task<IActionResult> GetTime()
        {
            return Ok(await _timeKeeperDataService.GetTimeKeepers());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTime(TimeKeeper time)
        {
            return Ok(await _timeKeeperDataService.CreateTimeKeepers(time));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTime(int id)
        {
            return Ok(await _timeKeeperDataService.DeleteTimeKeepers(id));
        }
    }
}
