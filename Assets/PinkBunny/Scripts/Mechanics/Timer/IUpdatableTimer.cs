namespace Laphed.Mechanics.AcceleratingTimer
{
    public interface IUpdatableTimer: ITimer
    {
        void SetDuration(float newDuration);
    }
}