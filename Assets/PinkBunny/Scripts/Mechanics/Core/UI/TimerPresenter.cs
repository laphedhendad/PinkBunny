using System;
using Laphed.MVP;

namespace Laphed.PinkBunny.UI
{
    public class TimerPresenter: Presenter<float, string>
    {
        public TimerPresenter(IView<string> view) : base(view)
        {
        }

        protected override void UpdateView(float value)
        {
            TimeSpan time = TimeSpan.FromSeconds(value);
            view.UpdateView(time.ToString(@"mm\:ss"));
        }
    }
}