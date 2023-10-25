using System;
using Laphed.EventBus;
using Zenject;

namespace Laphed.QTEBasedLevel
{
    public class InputSchemeSwitcher: IEventReceiver<LevelStarted>, IEventReceiver<LevelCompleted>, IEventReceiver<LevelFailed>, IDisposable
    {
        public UniqueId Id { get; } = new();
        
        private readonly IPlayerInput playerInput;
        private readonly IEventReceiverRegister eventBus;

        [Inject]
        public InputSchemeSwitcher(IPlayerInput playerInput, IEventReceiverRegister eventBus)
        {
            this.playerInput = playerInput;
            this.eventBus = eventBus;
            eventBus.Register<LevelStarted>(this);
            eventBus.Register<LevelCompleted>(this);
            eventBus.Register<LevelFailed>(this);
        }
        
        public void OnEvent(LevelStarted @event)
        {
            playerInput.SwitchToGameMode();
        }

        public void OnEvent(LevelCompleted @event)
        {
            playerInput.SwitchToUIMode();
        }

        public void OnEvent(LevelFailed @event)
        {
            playerInput.SwitchToUIMode();
        }

        public void Dispose()
        {
            eventBus.Unregister<LevelStarted>(this);
            eventBus.Unregister<LevelCompleted>(this);
            eventBus.Unregister<LevelFailed>(this);
        }
    }
}