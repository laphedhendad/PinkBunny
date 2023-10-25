namespace Laphed.EventBus
{
    public interface IEventRaiser
    {
        void Raise<T>(T @event) where T : struct, IEvent;
    }
}