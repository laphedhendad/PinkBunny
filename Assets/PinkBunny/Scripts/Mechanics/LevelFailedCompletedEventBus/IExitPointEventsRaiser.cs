namespace Laphed.Mechanics.LevelEventBus
{
    public interface IExitPointEventsRaiser
    {
        void RaiseLevelCompletedEvent();
        void RaiseLevelFailedEvent();
    }
}