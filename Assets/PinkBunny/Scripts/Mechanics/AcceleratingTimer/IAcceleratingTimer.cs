using UnityEngine;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public interface IAcceleratingTimer: ITimer
    {
        void Initialize(AnimationCurve curve);
        void UpdateCurve(AnimationCurve curve);
    }
}