using System;
using System.Collections.Generic;
using Laphed.Rx;

namespace Laphed.QTEBasedLevel
{
    public interface IQteQueue
    {
        event Action OnFailed;
        ReactiveProperty<bool> IsActivated { get; }
        void ActivateNextQuickTimeEvent();
        void SetTimerSettings(IEnumerable<QteData> timerSettings);
        bool IsEmpty();
        void Stop();
    }
}