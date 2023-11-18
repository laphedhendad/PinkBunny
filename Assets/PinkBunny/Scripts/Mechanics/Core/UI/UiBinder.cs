using Laphed.Timers;
using UnityEngine;
using UnityEngine.UI;

namespace Laphed.PinkBunny.UI
{
    public class UiBinder: MonoBehaviour
    {
        [SerializeField] private FilledImageIndicator filledImageIndicator;
        [SerializeField] private TimerView timerView;
        [SerializeField] private Button startButton;
        [SerializeField] private BatteriesView batteriesView;

        public void BindLevelTimer(ITimer timer)
        {
            TimerPresenter timerPresenter = new TimerPresenter(timerView);
            timerPresenter.SubscribeModel(timer.TimeLeft);
        }

        public void BindQteTimer(ITimer timer)
        {
            QuickTimeEventPresenter qtePresenter = new QuickTimeEventPresenter(filledImageIndicator, timer);
            qtePresenter.SubscribeModel(timer.TimeLeft);
        }

        public void BindStartButton(ILevelEntryPoint levelEntryPoint) => startButton.onClick.AddListener(levelEntryPoint.StartLevel);

        public void BindBatteries(IBatteriesPool batteriesPool)
        {
            BatteriesPresenter batteriesPresenter = new BatteriesPresenter(batteriesView);
            batteriesPresenter.SubscribeModel(batteriesPool.Counter);
        }

        private void OnDestroy() => startButton.onClick.RemoveAllListeners();
    }
}