using System.Collections.Generic;
using Laphed.Timer;

namespace Laphed.QTEBasedLevel
{
    public interface IQteQueue
    {
        void ActivateNextQuickTimeEvent();
        void SetTimerSettings(IEnumerable<AcceleratingTimerSettings> timerSettings);
        bool IsEmpty();
    }
}