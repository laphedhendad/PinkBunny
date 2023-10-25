using System;
using System.Collections.Generic;
using System.Linq;

namespace Laphed.EventBus
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<WeakReference<IBaseEventReceiver>>> receivers;
        private readonly Dictionary<string, WeakReference<IBaseEventReceiver>> receiverHashToReference;
        
        public EventBus()
        {
            receivers = new Dictionary<Type, List<WeakReference<IBaseEventReceiver>>>();
            receiverHashToReference = new Dictionary<string, WeakReference<IBaseEventReceiver>>();
        }

        public void Register<T>(IEventReceiver<T> receiver) where T : struct, IEvent
        {
            Type eventType = typeof(T);
            if (!receivers.ContainsKey(eventType))
                receivers[eventType] = new List<WeakReference<IBaseEventReceiver>>();

            if (!receiverHashToReference.TryGetValue(receiver.Id, out WeakReference<IBaseEventReceiver> reference))
            {
                reference = new WeakReference<IBaseEventReceiver>(receiver);
                receiverHashToReference[receiver.Id] = reference;
            }

            receivers[eventType].Add(reference);
        }

        public void Unregister<T>(IEventReceiver<T> receiver) where T : struct, IEvent
        {
            Type eventType = typeof(T);
            if (!receivers.ContainsKey(eventType) || !receiverHashToReference.ContainsKey(receiver.Id))
                return;

            WeakReference<IBaseEventReceiver> reference = receiverHashToReference[receiver.Id];

            receivers[eventType].Remove(reference);

            int weakRefCount = receivers.SelectMany(x => x.Value).Count(x => x == reference);
            if (weakRefCount == 0)
                receiverHashToReference.Remove(receiver.Id);
        }

        public void Raise<T>(T @event) where T : struct, IEvent
        {
            Type eventType = typeof(T);
            if (!receivers.ContainsKey(eventType))
                return;

            List<WeakReference<IBaseEventReceiver>> references = receivers[eventType];
            for (int i = references.Count - 1; i >= 0; i--)
            {
                if (references[i].TryGetTarget(out IBaseEventReceiver receiver))
                    ((IEventReceiver<T>)receiver).OnEvent(@event);
            }
        }
    }
}