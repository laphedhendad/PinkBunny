using System;

namespace Laphed.QTEBasedLevel
{
    public interface IPlayerInput
    {
        event Action OnClick;
        void Enable();
        void Disable();
    }
}