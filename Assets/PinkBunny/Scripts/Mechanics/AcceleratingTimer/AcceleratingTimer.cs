using System;
using System.Collections;
using Laphed.Utils.CoroutineProvider;
using Laphed.Utils.ExceptionsHandler;
using UnityEngine;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public class AcceleratingTimer: IAcceleratingTimer
    {
        public event Action OnTimerEnd;
        public event Action<float> OnTicked;
        
        private AnimationCurve curve;
        private float currentTime;
        private Coroutine timerCoroutine;
        private float realDuration;
        
        private readonly ICoroutineProvider coroutineProvider;

        public AcceleratingTimer(ICoroutineProvider coroutineProvider)
        {
            this.coroutineProvider = coroutineProvider;
        }

        public void Start(AnimationCurve curve)
        {
            this.curve = curve;
            realDuration = curve.keys[^1].time;
            currentTime = 0;
            timerCoroutine = coroutineProvider.StartCoroutine(RealTimerCoroutine());
        }
        
        public void Stop()
        {
            if (timerCoroutine == null) return;
            
            coroutineProvider.StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        public void Continue()
        {
            if (curve == null) throw new ContinueNotStartedTimerException();
            if (timerCoroutine != null) throw new ContinueNotStoppedTimerException();

            timerCoroutine = coroutineProvider.StartCoroutine(RealTimerCoroutine());
        }

        private void End()
        {
            OnTimerEnd?.Invoke();
        }

        private void Tick()
        {
            OnTicked?.Invoke(GetCurrentValue(currentTime));
        }

        private IEnumerator RealTimerCoroutine()
        {
            while (currentTime < realDuration)
            {
                currentTime += Time.deltaTime;
                Tick();
                
                yield return new WaitForEndOfFrame();
            }
            
            End();
        }

        private float GetCurrentValue(float realTime)
        {
            return curve.Evaluate(realTime);
        }
    }
}