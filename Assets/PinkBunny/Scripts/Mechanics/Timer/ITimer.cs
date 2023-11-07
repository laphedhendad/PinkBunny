using System;
using Laphed.Rx;

namespace Laphed.Timer
{
    public interface ITimer
    {
        float Duration { get; }
        void Start();
        event Action OnTimerEnd;
        ReactiveProperty<float> TimeLeft { get; }
        void Stop();
        void Continue();
    }
}