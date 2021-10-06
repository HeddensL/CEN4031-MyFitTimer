using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer.Server.Services
{
    public class StopwatchTrackerService : IStopwatchTrackerService
    {
        private bool is_stopwatchrunning = false;

        private TimeSpan _timer;

        public void Start()
        {
            is_stopwatchrunning = true;
            _timer = new TimeSpan();
            while (is_stopwatchrunning)
            {
                Task.Delay(1000);
                _timer = _timer.Add(new TimeSpan(0, 0, 1));
            }
        }

        public long GetElapsed()
        {
            return _timer.Ticks;
        }

        public void Stop()
        {
            is_stopwatchrunning = false;
        }        
    }
}
