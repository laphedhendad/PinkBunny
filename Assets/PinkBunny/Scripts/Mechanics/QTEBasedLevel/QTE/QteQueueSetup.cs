using System.Collections.Generic;
using Laphed.Timers;

namespace Laphed.QTEBasedLevel
{
    public struct QteQueueSetup
    {
        public IEnumerable<AcceleratingTimerSettings> timerSettings;
    }
}