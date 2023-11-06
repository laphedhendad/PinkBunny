using System;
using Laphed.InterfacesEventBus;
using Laphed.PinkBunny.UI;
using Laphed.QTEBasedLevel;
using Zenject;

namespace Laphed.PinkBunny
{
    public class LevelCompletedHandler: IEventReceiver<LevelCompleted>, IDisposable
    {
        private readonly IUiModeSwitch uiModeSwitch;
        private readonly IEventReceiverRegister eventBus;

        [Inject]
        public LevelCompletedHandler(IUiModeSwitch uiModeSwitch, IEventReceiverRegister eventBus)
        {
            this.uiModeSwitch = uiModeSwitch;
            this.eventBus = eventBus;
            eventBus.Register(this);
        }
        public void OnEvent(LevelCompleted @event)
        {
            uiModeSwitch.Switch();
        }

        public UniqueId Id { get; } = new();

        public void Dispose()
        {
            eventBus.Unregister(this);
        }
    }
}