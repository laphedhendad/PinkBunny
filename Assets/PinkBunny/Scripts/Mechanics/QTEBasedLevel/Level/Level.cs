using System;
using Laphed.LevelEventBus;
using Laphed.Timer;
using UnityEngine;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class Level: ILevel, IBuildableLevel, IDisposable
    {
        private readonly IQteQueue qteQueue;
        private readonly IExitPointEventsRaiser eventBus;
        private readonly IUpdatableTimer levelTimer;
        private readonly IAcceleratingTimer qteTimer;

        [Inject]
        public Level(
            IUpdatableTimer levelTimer,
            IAcceleratingTimer qteTimer,
            IQteQueue qteQueue,
            IExitPointEventsRaiser eventBus
        )
        {
            this.levelTimer = levelTimer;
            this.qteQueue = qteQueue;
            this.eventBus = eventBus;
            this.qteTimer = qteTimer;
            
            SubscribeOnTimersEvents();
        }
        
        public void Start()
        {
            levelTimer.Start();
            ToNextQte();
        }

        public void SetLevelTime(float time)
        {
            levelTimer.SetDuration(time);
        }

        public void ToNextQte()
        {
            if (qteQueue.IsEmpty()) return;
            qteQueue.ActivateNextQuickTimeEvent();
        }

        public void SetQteQueue(QteQueueSetup qteQueueSetup)
        {
            qteQueue.SetTimerSettings(qteQueueSetup.timerSettings);
        }

        private void Fail()
        {
            Debug.Log("Fail");
            eventBus.RaiseLevelFailedEvent();
        }

        private void Complete()
        {
            Debug.Log("Complete");
            eventBus.RaiseLevelCompletedEvent();
        }

        private void SubscribeOnTimersEvents()
        {
            levelTimer.OnTimerEnd += Complete;
            qteTimer.OnTimerEnd += Fail;
        }

        private void UnsubscribeFromTimersEvents()
        {
            levelTimer.OnTimerEnd -= Complete;
            qteTimer.OnTimerEnd -= Fail;
        }

        public void Dispose()
        {
            UnsubscribeFromTimersEvents();
        }
    }
}