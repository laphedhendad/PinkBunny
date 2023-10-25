using System;
using UnityEngine.InputSystem;

namespace Laphed.QTEBasedLevel
{
    public class PlayerInput: IPlayerInput, IDisposable
    {
        public event Action OnClick;
        private GameInput gameInput;
        private DefaultInputActions defaultInputActions;

        public PlayerInput()
        {
            InitializeInputSystem();
            SubscribeOnInputEvents();
        }

        private void InitializeInputSystem()
        {
            gameInput = new GameInput();
            gameInput.Enable();
            gameInput.UI.Enable();
            gameInput.Gameplay.Disable();
        }

        public void SwitchToGameMode()
        {
            gameInput.UI.Disable();
            gameInput.Gameplay.Enable();
        }

        public void SwitchToUIMode()
        {
            gameInput.Gameplay.Disable();
            gameInput.UI.Enable();
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