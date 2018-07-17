using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConfiguringApps.Infrastructure
{
    public class UptimeService
    {
        private Stopwatch timer;
        public long Uptime => timer.ElapsedMilliseconds;

        public UptimeService()
        {
            timer = Stopwatch.StartNew();
        }


    }
}
