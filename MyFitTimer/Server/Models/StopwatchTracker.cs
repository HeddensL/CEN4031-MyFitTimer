using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer.Server.Models
{
    public class StopwatchTracker
    {
        private bool is_stopwatchrunning = false;

        private TimeSpan _timer;

        public void async Task Start()
        {
            is_stopwatchrunning = true;
            _timer = new TimeSpan();
            while (is_stopwatchrunning)
            {
                Task.Delay(1000);
                if (is_stopwatchrunning)
                {
                    _timer = _timer.Add(new TimeSpan(0, 0, 1));
                }
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


















        //return currently elapsed time
        public TimeSpan GetElapsed()
        {
            return timer.Elapsed;
        }

        //returns previous lap
        public long GetLap()
        {
            return lap.Ticks;
        }

        public void Restart()
        {
            timer.Reset();
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            lap = timer.Elapsed;
        }

        //creates new stopwatch object
        private Stopwatch timer = new Stopwatch();

        //creates new timespan object to hold time
        private TimeSpan lap = new TimeSpan();
    }
}
