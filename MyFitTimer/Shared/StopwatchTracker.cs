using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitTimer.Shared
{
    public class StopwatchTracker
    {
        public int Start { get; set; }

        public int Stop { get; set; }

        public long Elapsed { get; set; }
    }
}
