using UnityEngine;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public interface IAcceleratingTimer: ITimer
    {
        void UpdateCurve(AnimationCurve curve);
    }
}