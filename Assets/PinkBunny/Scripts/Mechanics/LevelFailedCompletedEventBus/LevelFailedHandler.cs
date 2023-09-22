namespace Laphed.Mechanics.LevelEventBus
{
    public abstract class LevelFailedHandler: ILevelFailedHandler
    {
        private EventBus eventBus;

        protected LevelFailedHandler(EventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public abstract void OnLevelFailed();
    }
}