using System;
using Laphed.LevelEventBus;
using Laphed.Timer;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class LevelExitPointsTracker: IDisposable
    {
        private readonly IExitPointEventsRaiser eventBus;
        private readonly IUpdatableTimer levelTimer;
        private readonly IAcceleratingTimer qteTimer;

        [Inject]
        public LevelExitPointsTracker(
            IExitPointEventsRaiser eventBus,
            IUpdatableTimer levelTimer, 
            IAcceleratingTimer qteTimer
            )
        {
            this.eventBus = eventBus;
            this.levelTimer = levelTimer;
            this.qteTimer = qteTimer;
            BindTimerEvents();
        }

        private void BindTimerEvents()
        {
            levelTimer.OnTimerEnd += eventBus.RaiseLevelCompletedEvent;
            qteTimer.OnTimerEnd += eventBus.RaiseLevelFailedEvent;
        }
        
        private void UnbindTimerEvents()
        {
            levelTimer.OnTimerEnd -= eventBus.RaiseLevelCompletedEvent;
            qteTimer.OnTimerEnd -= eventBus.RaiseLevelFailedEvent;
        }

        public void Dispose()
        {
            UnbindTimerEvents();
        }
    }
}