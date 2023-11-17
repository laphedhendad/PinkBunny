using Laphed.Rx;

namespace Laphed.PinkBunny
{
    public interface IBatteriesPool
    {
        ReactiveProperty<int> Counter { get; }
        void TryUseBattery();
        void SetBatteriesAmount(int amount);
    }
}