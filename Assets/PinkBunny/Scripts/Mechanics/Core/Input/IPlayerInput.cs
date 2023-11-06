using System;

namespace Laphed.PinkBunny
{
    public interface IPlayerInput
    {
        event Action OnClick;
        void SwitchToGameMode();
        void SwitchToUIMode();
    }
}