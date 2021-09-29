using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer.Server
{
    public class StopwatchTracker
    {
        public TimeSpan GetElapsed()
        {
            return lap;
        }

        //creates new stopwatch object
        private Stopwatch timer = new Stopwatch();

        //creates new timespan object
        private TimeSpan lap = new TimeSpan();
    }
}
