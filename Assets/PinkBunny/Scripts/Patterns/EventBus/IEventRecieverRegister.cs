namespace Laphed.EventBus
{
    public interface IEventReceiverRegister
    {
        public void Register<T>(IEventReceiver<T> receiver) where T : struct, IEvent;
        public void Unregister<T>(IEventReceiver<T> receiver) where T : struct, IEvent;
    }
}