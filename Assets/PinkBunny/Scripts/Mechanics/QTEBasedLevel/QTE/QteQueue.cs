using System;
using System.Collections.Generic;
using Laphed.Rx;
using Laphed.Timers;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class QteQueue: IQteQueue, IDisposable
    {
        public event Action OnFailed;
        public ReactiveProperty<bool> IsActivated { get; } = new();
        private Queue<QteData> timerSettingsQueue;
        private readonly ITimer timer;
        private QteData currentQte;

        [Inject]
        public QteQueue([Inject(Id = TimerType.Qte)] ITimer timer)
        {
            this.timer = timer;
            SubscribeTimer();
        }

        public void SetTimerSettings(IEnumerable<QteData> timerSettings)
        {
            timerSettingsQueue = new Queue<QteData>(timerSettings);
        }
        
        public void ActivateNextQuickTimeEvent()
        {
            timer.Stop();
            currentQte = timerSettingsQueue.Dequeue();
            timer.Duration = currentQte.delay;
            timer.Start();
            timer.TimeLeft.OnChanged += HandleTimerTick;
        }

        public bool IsEmpty()
        {
            return timerSettingsQueue.Count == 0;
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void SubscribeTimer()
        {
            timer.OnTimerEnd += Fail;
            timer.TimeLeft.OnChanged += HandleTimerTick;
        }
        
        private void UnsubscribeTimer()
        {
            timer.OnTimerEnd -= Fail;
            timer.TimeLeft.OnChanged -= HandleTimerTick;
        }

        private void Fail() => OnFailed?.Invoke();

        private void HandleTimerTick()
        {
            float timeLeft = timer.TimeLeft.Value;
            if (timeLeft > currentQte.clickWindow) return;
            IsActivated.Value = true;
            timer.TimeLeft.OnChanged -= HandleTimerTick;
        }

        public void Dispose()
        {
            UnsubscribeTimer();
        }
    }
}