using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Laphed.ExceptionsHandler;
using Laphed.Rx;

namespace Laphed.Timers
{
    public class Timer: ITimer
    {
        public event Action OnTimerEnd;
        public ReactiveProperty<float> TimeLeft { get; } = new();
        protected float realTime;

        private float duration;
        public float Duration
        {
            get => duration;
            set
            {
                if (cancellationToken != null) throw new UpdateActiveTimerDurationException();
                duration = value;
            }
        }
        
        private CancellationTokenSource cancellationToken;

        public Timer()
        {
        }

        public Timer(float duration)
        {
            this.duration = duration;
        }

        public virtual async void Start()
        {
            Stop();
            
            cancellationToken = new CancellationTokenSource();
            realTime = Duration;
            TimeLeft.Value = realTime;

            try
            {
                await StartTimer(cancellationToken.Token);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                ClearCancellationToken();
            }
        }
        
        public void Stop()
        {
            cancellationToken?.Cancel();
        }

        public virtual async void Continue()
        {
            if (cancellationToken != null) throw new ContinueNotStoppedTimerException();
            
            cancellationToken = new CancellationTokenSource();

            try
            {
                await StartTimer(cancellationToken.Token);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                ClearCancellationToken();
            }
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

        private async UniTask StartTimer(CancellationToken token)
        {
            while (realTime > 0)
            {
                if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
                realTime -= TimersRatio.Seconds;
                Tick();
                await UniTask.Delay(TimersRatio.Milliseconds);
            }
            
            End();
        }

        private void ClearCancellationToken()
        {
            cancellationToken.Dispose();
            cancellationToken = null;
        }
    }
}