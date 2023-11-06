using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using Zenject;

namespace Laphed.PinkBunny
{
    public class PlayerInput: IPlayerInput, IDisposable
    {
        public event Action OnClick;
        private readonly InputSystemUIInputModule uiInputModule;
        private GameInput gameInput;
        private DefaultInputActions defaultInputActions;

        [Inject]
        public PlayerInput(InputSystemUIInputModule uiInputModule)
        {
            this.uiInputModule = uiInputModule;
            InitializeInputSystem();
            SubscribeOnInputEvents();
        }

        private void InitializeInputSystem()
        {
            gameInput = new GameInput();
            gameInput.Enable();
            gameInput.Gameplay.Disable();
        }

        public void SwitchToGameMode()
        {
            uiInputModule.actionsAsset.Disable();
            gameInput.Gameplay.Enable();
        }

        public void SwitchToUIMode()
        {
            gameInput.Gameplay.Disable();
            uiInputModule.actionsAsset.Enable();
        }

        private void SubscribeOnInputEvents()
        {
            gameInput.Gameplay.Click.performed += HandleClick;
        }

        private void UnsubscribeFromInputEvents()
        {
            gameInput.Gameplay.Click.performed -= HandleClick;
        }
        
        private void HandleClick(InputAction.CallbackContext obj)
        {
            OnClick?.Invoke();
        }

        public void Dispose()
        {
            UnsubscribeFromInputEvents();
        }
    }
}