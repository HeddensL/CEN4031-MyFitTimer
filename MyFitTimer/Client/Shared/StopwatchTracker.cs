using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFitTimer.Client.Services;
using System.Diagnostics;
using MyFitTimer.Shared;

namespace MyFitTimer.Client.Shared
{
    public class StopwatchTracker
    {

        //return currently elapsed time
        public TimeSpan GetElapsed()
        {
            lap = TimeSpan.FromMilliseconds(timer.ElapsedMilliseconds);
            TimeSpan.TryParse(lap.ToString(@"hh\:mm\:ss"), out lap);
            return lap;
        }

        //returns previous lap
        public Stopwatcher GetLap()
        {
            EndTime.Time = lap.Ticks;
            return EndTime;
        }

        //restarts timer
        public void Restart()
        {
            timer.Start();
        }

        //stops timer
        public void Stop()
        {
            timer.Stop();
            lap = TimeSpan.FromMilliseconds(timer.ElapsedMilliseconds);
            timer.Reset();
            TimeSpan.TryParse(lap.ToString(@"hh\:mm\:ss"), out lap);
        }

        //determin timer state
        public bool Running()
        {
            return timer.IsRunning;
        }

        //creates new stopwatch object
        private Stopwatch timer = new Stopwatch();

        //creates new timespan object to hold time
        private TimeSpan lap = new TimeSpan(0, 0, 0);

        //stopwatcher object
        private Stopwatcher EndTime = new Stopwatcher();        
    }
}
