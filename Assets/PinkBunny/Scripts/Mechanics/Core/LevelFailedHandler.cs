using System;
using Laphed.Horror;
using Laphed.InterfacesEventBus;
using Laphed.PinkBunny.UI;
using Laphed.QTEBasedLevel;
using Zenject;

namespace Laphed.PinkBunny
{
    public class LevelFailedHandler: IEventReceiver<LevelFailed>, IDisposable
    {
        private readonly IUiModeSwitch uiModeSwitch;
        private readonly IEventReceiverRegister eventBus;
        private readonly IScreamer screamer;

        [Inject]
        public LevelFailedHandler(IUiModeSwitch uiModeSwitch, Screamer.Factory screamerFactory, Cutscenes cutscenes, IEventReceiverRegister eventBus)
        {
            this.uiModeSwitch = uiModeSwitch;
            this.eventBus = eventBus;
            screamer = screamerFactory.Create(cutscenes.levelFailedScreamer);
            eventBus.Register(this);
        }
        
        public async void OnEvent(LevelFailed @event)
        {
            await screamer.Show();
            await uiModeSwitch.Switch();
        }

        public UniqueId Id { get; } = new();

        public void Dispose()
        {
            eventBus.Unregister(this);
        }
    }
}