namespace Laphed.InterfacesEventBus
{
    public interface IEventRaiser
    {
        void Raise<T>(T @event) where T : struct, IEvent;
    }
}