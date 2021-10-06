using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Shared;

namespace MyFitTimer.Server.Services
{
    public interface ITimeKeeperDataService
    {        
        Task<List<TimeKeeper>> GetTimeKeepers();

        Task<List<TimeKeeper>> CreateTimeKeepers(TimeKeeper time);

        Task<TimeKeeper> GetLatestTimeKeepers();

        Task<List<TimeKeeper>> DeleteTimeKeepers(int id);
    }
}
