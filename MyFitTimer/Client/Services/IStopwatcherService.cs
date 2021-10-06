using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Shared;

namespace MyFitTimer.Client.Services
{
    public interface IStopwatcherService
    {
        event Action OnChange;

        List<Stopwatcher> NewestTime { get; set; }            

        Stopwatcher Latest { get; set; }

        Task<Stopwatcher> LatestTime();

        Task<List<Stopwatcher>> CreateStopwatcher(Stopwatcher newTime);

    }
}