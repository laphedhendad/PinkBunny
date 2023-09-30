namespace Laphed.Mechanics.Timer
{
    public interface IUpdatableTimer: ITimer
    {
        void SetDuration(float newDuration);
    }
}