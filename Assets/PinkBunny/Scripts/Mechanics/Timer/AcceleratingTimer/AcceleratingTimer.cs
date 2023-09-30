using Laphed.Utils.CoroutineProvider;
using Laphed.Utils.ExceptionsHandler;
using UnityEngine;

namespace Laphed.Mechanics.Timer
{
    public class AcceleratingTimer: Timer, IAcceleratingTimer
    {
        private AnimationCurve curve;
        
        public AcceleratingTimer(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }

        private void Initialize(AcceleratingTimerSettings settings)
        {
            curve = settings.curve;
            duration = curve.keys[^1].time;
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
            InvokeOnTicked(GetCurrentValue(currentTime));
        }

        private float GetCurrentValue(float realTime)
        {
            return curve.Evaluate(realTime);
        }
    }
}