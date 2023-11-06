namespace Laphed.PinkBunny
{
    public interface IBatteriesPool
    {
        int Counter { get; }
        void UseBattery();
        void SetBatteriesAmount(int amount);
    }
}