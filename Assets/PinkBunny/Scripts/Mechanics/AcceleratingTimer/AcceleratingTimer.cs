using System;
using UnityEngine;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public class AcceleratingTimer
    {
        public event Action<float> onTicked; 
        public event Action onTimerEnd;
        
        private AnimationCurve curve;

        public AcceleratingTimer(AcceleratingTimerData timerData)
        {
            curve = timerData.curve;
        }
        
        
    }
}