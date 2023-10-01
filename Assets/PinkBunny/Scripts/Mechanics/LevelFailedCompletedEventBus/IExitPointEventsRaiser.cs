namespace Laphed.LevelEventBus
{
    public interface IExitPointEventsRaiser
    {
        void RaiseLevelCompletedEvent();
        void RaiseLevelFailedEvent();
    }
}