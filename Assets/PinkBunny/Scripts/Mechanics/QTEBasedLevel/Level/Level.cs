using System;
using Laphed.InterfacesEventBus;
using Laphed.Timers;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class Level: IBuildableLevel, IDisposable
    {
        private readonly IQteQueue qteQueue;
        private readonly IEventRaiser eventBus;
        private readonly ITimer levelTimer;
        private readonly IAcceleratingTimer qteTimer;

        [Inject]
        public Level(
            [Inject(Id = TimerType.Level)] ITimer levelTimer,
            [Inject(Id = TimerType.Qte)] IAcceleratingTimer qteTimer,
            IQteQueue qteQueue,
            IEventRaiser eventBus
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
            eventBus.Raise(new LevelStarted());
            levelTimer.Start();
            ToNextQte();
        }

        public void SetLevelTime(float time) => levelTimer.Duration = time;

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
            levelTimer.Stop();
            eventBus.Raise(new LevelFailed());
        }

        private void Complete()
        {
            eventBus.Raise(new LevelCompleted());
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