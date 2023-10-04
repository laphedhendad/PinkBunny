using System;

namespace Laphed.Timer
{
    public interface ITimer
    {
        float Duration { get; }
        void Start();
        event Action OnTimerEnd;
        event Action<float> OnTicked;
        void Stop();
        void Continue();
    }
}