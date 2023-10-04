using System;
using Laphed.Timer;

namespace Laphed.QTEBasedLevel.UI
{
    public class TimerPresenter: Presenter<float, string>, IDisposable
    {
        private readonly ITimer timer;

        public TimerPresenter(IView<string> view, ITimer timer) : base(view)
        {
            this.timer = timer;
            SubscribeOnTimerTicked();
        }

        private void SubscribeOnTimerTicked()
        {
            timer.OnTicked += UpdateView;
        }

        private void UnsubscribeOnTimerTicked()
        {
            timer.OnTicked -= UpdateView;
        }
        
        protected override void UpdateView(float value)
        {
            TimeSpan time = TimeSpan.FromSeconds(value);
            view.UpdateView(time.ToString(@"mm\:ss"));
        }

        public void Dispose()
        {
            UnsubscribeOnTimerTicked();
        }
    }
}