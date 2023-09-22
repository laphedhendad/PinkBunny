using System;
using UnityEngine;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public interface IAcceleratingTimer
    {
        void Start(AnimationCurve curve);
        event Action OnTimerEnd;
        event Action<float> OnTicked;
        void Stop();
        void Continue();
    }
}