using Laphed.QTEBasedLevel;
using Laphed.Rx;
using Zenject;

namespace Laphed.PinkBunny
{
    public class BatteriesPool: IBatteriesPool
    {
        public ReactiveProperty<int> Counter { get; } = new();
        private readonly ILevel level;

        [Inject]
        public BatteriesPool(ILevel level)
        {
            this.level = level;
        }
        
        public void TryUseBattery()
        {
            if (Counter.Value == 0) return;
            
            level.ToNextQte();
            Counter.Value--;
        }

        public void SetBatteriesAmount(int amount)
        {
            Counter.Value = amount;
        }
    }
}