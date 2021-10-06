using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Shared;

namespace MyFitTimer.Client.Services
{
    interface IStopwatchTrackerService
    {
        event Action OnChange;

        StopwatchTracker ElapsedTime { get; set; }

        Task<StopwatchTracker> Start();

        Task<StopwatchTracker> Stop();

        Task<StopwatchTracker> GetElapsed();
    }
}
