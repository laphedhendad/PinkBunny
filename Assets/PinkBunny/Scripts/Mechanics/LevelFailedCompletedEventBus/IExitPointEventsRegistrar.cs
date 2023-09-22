namespace Laphed.Mechanics.LevelEventBus
{
    public interface IExitPointEventsRegistrar
    {
        void SubscribeOnLevelCompleted(ILevelCompletedHandler levelCompletedHandler);
        void UnsubscribeLevelCompleted(ILevelCompletedHandler levelCompletedHandler);
        void SubscribeOnLevelFailed(ILevelFailedHandler levelFailedHandler);
        void UnsubscribeLevelFailed(ILevelFailedHandler levelFailedHandler);
    }
}