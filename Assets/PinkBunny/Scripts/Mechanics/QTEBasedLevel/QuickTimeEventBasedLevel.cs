using System;
using Laphed.Mechanics.LevelEventBus;
using UnityEngine;
using Zenject;

namespace Laphed.Mechanics.QTEBasedLevel
{
    public class QuickTimeEventBasedLevel: ILevelCompletedHandler, ILevelFailedHandler, IDisposable
    {
        private readonly IExitPointEventsRegistrar eventBus;
        
        [Inject]
        public QuickTimeEventBasedLevel(IExitPointEventsRegistrar eventBus)
        {
            this.eventBus = eventBus;
            eventBus.SubscribeOnLevelCompleted(this);
            eventBus.SubscribeOnLevelFailed(this);
        }
        
        public void OnLevelCompleted()
        {
            Debug.Log("Level Completed");
        }

        public void OnLevelFailed()
        {
            Debug.Log("Level Failed");
        }

        public void Dispose()
        {
            eventBus.UnsubscribeLevelCompleted(this);
            eventBus.UnsubscribeLevelFailed(this);
        }
    }
}