using System;
using System.Collections;
using Laphed.CoroutinesProvider;
using Laphed.ExceptionsHandler;
using Laphed.Rx;
using UnityEngine;

namespace Laphed.Timer
{
    public class Timer: ITimer
    {
        public event Action OnTimerEnd;
        public ReactiveProperty<float> TimeLeft { get; } = new();

        protected float realTime;
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
            
            realTime = Duration;
            TimeLeft.Value = realTime;
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
            TimeLeft.Value = realTime;
        }

        private IEnumerator RealTimerCoroutine()
        {
            while (realTime > 0)
            {
                realTime -= Time.deltaTime;
                Tick();
                
                yield return new WaitForEndOfFrame();
            }
            
            End();
        }
    }
}