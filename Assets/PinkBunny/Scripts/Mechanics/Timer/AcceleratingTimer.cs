using Laphed.Utils.CoroutineProvider;
using Laphed.Utils.ExceptionsHandler;
using UnityEngine;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public class AcceleratingTimer: Timer, IAcceleratingTimer
    {
        private AnimationCurve curve;
        
        public AcceleratingTimer(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }

        private void Initialize(AnimationCurve curve)
        {
            this.curve = curve;
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

        public void UpdateCurve(AnimationCurve curve)
        {
            Initialize(curve);
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