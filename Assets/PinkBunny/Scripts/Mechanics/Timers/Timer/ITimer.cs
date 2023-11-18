using System;
using Laphed.Rx;

namespace Laphed.Timers
{
    public interface ITimer
    {
        float Duration { get; set; }
        void Start();
        event Action OnTimerEnd;
        ReactiveProperty<float> TimeLeft { get; }
        void Stop();
        void Continue();
    }
}