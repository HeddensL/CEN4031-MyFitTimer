using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Shared;

namespace MyFitTimer.Client.Services
{
    public interface ITimeKeeperService
    {
        event Action OnChange;

        List<TimeKeeper> Times { get; set; }

        Task<List<TimeKeeper>> GetTimeKeepers();

        Task<List<TimeKeeper>> CreateTimeKeeper(TimeKeeper time);

        Task<List<TimeKeeper>> DeleteTimeKeeper(int id);
    }
}
