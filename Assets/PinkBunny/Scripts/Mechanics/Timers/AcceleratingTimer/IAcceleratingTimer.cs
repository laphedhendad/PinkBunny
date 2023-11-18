namespace Laphed.Timers
{
    public interface IAcceleratingTimer: ITimer
    {
        void UpdateCurve(AcceleratingTimerSettings settings);
    }
}