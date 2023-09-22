using System.Collections.Generic;

namespace Laphed.Mechanics.LevelEventBus
{
    public class EventBus: IExitPointEventsRaiser, IExitPointEventsRegistrar
    {
        private readonly List<ILevelCompletedHandler> levelCompletedHandlers;
        private readonly List<ILevelFailedHandler> levelFailedHandlers;

        public EventBus()
        {
            levelCompletedHandlers = new List<ILevelCompletedHandler>();
            levelFailedHandlers = new List<ILevelFailedHandler>();
        }

        public void SubscribeOnLevelCompleted(ILevelCompletedHandler levelCompletedHandler)
        {
            if (levelCompletedHandlers.Contains(levelCompletedHandler)) return;
            
            levelCompletedHandlers.Add(levelCompletedHandler);
        }

        public void UnsubscribeLevelCompleted(ILevelCompletedHandler levelCompletedHandler)
        {
            if (!levelCompletedHandlers.Contains(levelCompletedHandler)) return;
            
            levelCompletedHandlers.Remove(levelCompletedHandler);
        }
        
        public void SubscribeOnLevelFailed(ILevelFailedHandler levelFailedHandler)
        {
            if (levelFailedHandlers.Contains(levelFailedHandler)) return;
            
            levelFailedHandlers.Add(levelFailedHandler);
        }
        
        public void UnsubscribeLevelFailed(ILevelFailedHandler levelFailedHandler)
        {
            if (!levelFailedHandlers.Contains(levelFailedHandler)) return;
                
            levelFailedHandlers.Remove(levelFailedHandler);
        }

        public void RaiseLevelCompletedEvent()
        {
            foreach (ILevelCompletedHandler levelCompletedHandler in levelCompletedHandlers)
            {
                levelCompletedHandler.OnLevelCompleted();
            }
        }

        public void RaiseLevelFailedEvent()
        {
            foreach (ILevelFailedHandler levelFailedHandler in levelFailedHandlers)
            {
                levelFailedHandler.OnLevelFailed();
            }
        }
    }
}