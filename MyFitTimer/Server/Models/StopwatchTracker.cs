using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer.Server
{
    public class StopwatchTracker
    {
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
