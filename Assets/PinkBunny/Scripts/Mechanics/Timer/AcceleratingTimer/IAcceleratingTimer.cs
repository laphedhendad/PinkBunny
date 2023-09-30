namespace Laphed.Mechanics.Timer
{
    public interface IAcceleratingTimer: ITimer
    {
        void UpdateCurve(AcceleratingTimerSettings settings);
    }
}