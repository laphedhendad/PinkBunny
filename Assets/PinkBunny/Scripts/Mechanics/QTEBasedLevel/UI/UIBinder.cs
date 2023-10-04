using Laphed.Timer;
using UnityEngine;
using UnityEngine.UI;

namespace Laphed.QTEBasedLevel.UI
{
    public class UIBinder: MonoBehaviour
    {
        [SerializeField] private FilledImageIndicator filledImageIndicator;
        [SerializeField] private TimerView timerView;
        [SerializeField] private Button startButton;
        
        public void Bind(ITimer levelTimer, ITimer qteTimer, ILevel level)
        {
            TimerPresenter timerPresenter = new TimerPresenter(timerView, levelTimer);
            QuickTimeEventPresenter qtePresenter = new QuickTimeEventPresenter(filledImageIndicator, qteTimer);
            startButton.onClick.AddListener(level.Start);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
        }
    }
}