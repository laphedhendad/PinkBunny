using Laphed.MVP;
using Laphed.Timer;

namespace Laphed.PinkBunny.UI
{
    public class QuickTimeEventPresenter: Presenter<float>
    {
        private readonly ITimer qteTimer;

        public QuickTimeEventPresenter(IView<float> view, ITimer qteTimer): base(view)
        {
            this.qteTimer = qteTimer;
        }

        protected override void UpdateView(float value)
        {
            view.UpdateView(value/qteTimer.Duration);
        }
    }
}