using Laphed.Rx;

namespace Laphed.PinkBunny
{
    public interface IBatteriesPool
    {
        ReactiveProperty<int> Counter { get; }
        bool TryUseBattery();
        void SetBatteriesAmount(int amount);
    }
}