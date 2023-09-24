namespace Laphed.Mechanics.AcceleratingTimer
{
    public interface ITimerFactory<T> where T: ITimer
    {
        T Create();
    }
}