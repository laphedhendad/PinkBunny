namespace Laphed.Timer
{
    public interface ITimerFactory<T> where T: ITimer
    {
        T Create();
    }
}