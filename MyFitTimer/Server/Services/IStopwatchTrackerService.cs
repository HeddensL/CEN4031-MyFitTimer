using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer.Server.Services
{
    public interface IStopwatchTrackerService
    {
        void Start();

        long GetElapsed();

        void Stop();

    }
}
