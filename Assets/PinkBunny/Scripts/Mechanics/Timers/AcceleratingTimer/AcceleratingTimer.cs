using Laphed.ExceptionsHandler;
using UnityEngine;

namespace Laphed.Timers
{
    public class AcceleratingTimer: Timer, IAcceleratingTimer
    {
        private AnimationCurve curve;

        private void Initialize(AcceleratingTimerSettings settings)
        {
            curve = settings.curve;
            Duration = curve.keys[^1].time;
        }

        public override void Start()
        {
            if (curve == null) throw new StartNotInitializedTimerException();
            
            base.Start();
        }

        public override void Continue()
        {
            if (curve == null) throw new ContinueNotStartedTimerException();
            
            base.Continue();
        }

        public void UpdateCurve(AcceleratingTimerSettings settings)
        {
            Initialize(settings);
        }

        protected override void Tick()
        {
            TimeLeft.Value = GetCurrentValue(realTime);
        }

        private float GetCurrentValue(float realTime)
        {
            return curve.Evaluate(Duration - realTime);
        }
    }
}