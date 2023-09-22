namespace Laphed.Mechanics.LevelEventBus
{
    public abstract class LevelCompletedHandler: ILevelCompletedHandler
    {
        private EventBus eventBus;

        protected LevelCompletedHandler(EventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public abstract void OnLevelCompleted();
    }
}