using System;
using System.Collections;
using Laphed.CoroutineProvider;
using Laphed.ExceptionsHandler;
using UnityEngine;

namespace Laphed.Timer
{
    public class Timer: ITimer
    {
        public event Action OnTimerEnd;
        public event Action<float> OnTicked;
        
        protected float currentTime;
        public float Duration { get; protected set; }

        private Coroutine timerCoroutine;
        private readonly ICoroutineProvider coroutineProvider;

        public Timer(ICoroutineProvider coroutineProvider)
        {
            this.coroutineProvider = coroutineProvider;
        }

        public virtual void Start()
        {
            if(timerCoroutine != null) coroutineProvider.StopCoroutine(timerCoroutine);
            
            currentTime = Duration;
            timerCoroutine = coroutineProvider.StartCoroutine(RealTimerCoroutine());
        }
        
        public void Stop()
        {
            if (timerCoroutine == null) return;
            
            coroutineProvider.StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        public virtual void Continue()
        {
            if (timerCoroutine != null) throw new ContinueNotStoppedTimerException();

            timerCoroutine = coroutineProvider.StartCoroutine(RealTimerCoroutine());
        }

        private void End()
        {
            Stop();
            OnTimerEnd?.Invoke();
        }

        protected virtual void Tick()
        {
            OnTicked?.Invoke(currentTime);
        }

        private IEnumerator RealTimerCoroutine()
        {
            while (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                Tick();
                
                yield return new WaitForEndOfFrame();
            }
            
            End();
        }

        protected void InvokeOnTicked(float value)
        {
            OnTicked?.Invoke(value);
        }
    }
}