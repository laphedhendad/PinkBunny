using System;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public interface ITimer
    {
        void Start();
        event Action OnTimerEnd;
        event Action<float> OnTicked;
        void Stop();
        void Continue();
    }
}