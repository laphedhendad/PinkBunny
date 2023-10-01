namespace Laphed.Timer
{
    public interface IUpdatableTimer: ITimer
    {
        void SetDuration(float newDuration);
    }
}