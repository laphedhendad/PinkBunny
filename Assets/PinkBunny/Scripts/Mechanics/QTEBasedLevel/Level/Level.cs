using System;
using System.Collections.Generic;
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

        [Inject]
        public Level(
            [Inject(Id = TimerType.Level)] ITimer levelTimer,
            IQteQueue qteQueue,
            IEventRaiser eventBus
        )
        {
            this.levelTimer = levelTimer;
            this.qteQueue = qteQueue;
            this.eventBus = eventBus;

            SubscribeEvents();
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

        public void SetQteQueue(IEnumerable<QteData> qteQueueSetup)
        {
            qteQueue.SetTimerSettings(qteQueueSetup);
        }

        private void Fail()
        {
            levelTimer.Stop();
            eventBus.Raise(new LevelFailed());
        }

        private void Complete()
        {
            qteQueue.Stop();
            eventBus.Raise(new LevelCompleted());
        }

        private void SubscribeEvents()
        {
            levelTimer.OnTimerEnd += Complete;
            qteQueue.OnFailed += Fail;
        }

        private void UnsubscribeEvents()
        {
            levelTimer.OnTimerEnd -= Complete;
            qteQueue.OnFailed -= Fail;
        }

        public void Dispose()
        {
            UnsubscribeEvents();
        }
    }
}