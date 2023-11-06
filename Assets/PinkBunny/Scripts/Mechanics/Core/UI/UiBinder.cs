﻿using Laphed.QTEBasedLevel;
using Laphed.Timer;
using UnityEngine;
using UnityEngine.UI;

namespace Laphed.PinkBunny.UI
{
    public class UiBinder: MonoBehaviour
    {
        [SerializeField] private FilledImageIndicator filledImageIndicator;
        [SerializeField] private TimerView timerView;
        [SerializeField] private Button startButton;

        private TimerPresenter timerPresenter;
        private QuickTimeEventPresenter qtePresenter;
        
        public void Bind(ITimer levelTimer, ITimer qteTimer, ILevelEntryPoint levelEntryPoint)
        {
            timerPresenter = new TimerPresenter(timerView, levelTimer);
            qtePresenter = new QuickTimeEventPresenter(filledImageIndicator, qteTimer);
            startButton.onClick.AddListener(levelEntryPoint.StartLevel);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
        }
    }
}