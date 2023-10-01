namespace Laphed.Timer
{
    public interface IAcceleratingTimer: ITimer
    {
        void UpdateCurve(AcceleratingTimerSettings settings);
    }
}