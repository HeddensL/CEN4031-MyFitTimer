using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Shared;
using MyFitTimer.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace MyFitTimer.Server.Services
{
    public class TimeKeeperDataService : ITimeKeeperDataService
    {
        private readonly TimeKeeperContext _context;

        public TimeKeeperDataService(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<List<TimeKeeper>> CreateTimeKeepers(TimeKeeper time)
        {
            _context.Add(time);
            await _context.SaveChangesAsync();

            return await _context.TimeKeepers.ToListAsync();
        }

        public static TimeKeeper List { get; set; } = new TimeKeeper()
        {
           Id = 0, Time = 0
        };

        public async Task<List<TimeKeeper>> DeleteTimeKeepers(int id)
        {
            //return notfound - unsure if proper?
            /*var dbTime = _context.TimeKeepers.FirstOrDefault(t => t.Id == id);
            if (dbTime == null)
                return NotFound("Time Not Found");*/

            _context.Remove(_context.TimeKeepers.Single(t => t.Id == id));
            await _context.SaveChangesAsync();

            return await _context.TimeKeepers.ToListAsync();
        }

        public async Task<TimeKeeper> GetLatestTimeKeepers()
        {
            if(_context.TimeKeepers.FirstOrDefault() == null)
                return List;
            
            int latestTime = _context.TimeKeepers.Max(l => l.Id);
            return await _context.TimeKeepers.SingleAsync(t => t.Id == latestTime);
        }

        public async Task<List<TimeKeeper>> GetTimeKeepers()
        {
            return await _context.TimeKeepers.ToListAsync();
        }

        //legacy list for populating webpage table
        /*public List<TimeKeeper> TimeKeepers { get; set; } = new List<TimeKeeper>
        {
            new TimeKeeper { Id = 1, Time = 10000000000},
            new TimeKeeper { Id = 2, Time = 21154564000}
        };*/
    }
}
