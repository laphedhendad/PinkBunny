using System;
using Laphed.Timer;

namespace Laphed.PinkBunny.UI
{
    public class QuickTimeEventPresenter: Presenter<float>, IDisposable
    {
        private readonly ITimer qteTimer;

        public QuickTimeEventPresenter(IView<float> view, ITimer qteTimer): base(view)
        {
            this.qteTimer = qteTimer;
            SubscribeOnTimerTicked();
        }

        private void SubscribeOnTimerTicked()
        {
            qteTimer.OnTicked += UpdateView;
        }

        private void UnsubscribeOnTimerTicked()
        {
            qteTimer.OnTicked -= UpdateView;
        }

        protected override void UpdateView(float value)
        {
            view.UpdateView(value/qteTimer.Duration);
        }
        
        public void Dispose()
        {
            UnsubscribeOnTimerTicked();
        }

    }
}