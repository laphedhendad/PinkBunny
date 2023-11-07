using Laphed.QTEBasedLevel;
using Laphed.Rx;
using Zenject;

namespace Laphed.PinkBunny
{
    public class BatteriesPool: IBatteriesPool
    {
        public ReactiveProperty<int> Counter { get; private set; }
        private readonly ILevel level;

        [Inject]
        public BatteriesPool(ILevel level)
        {
            this.level = level;
        }
        
        public bool TryUseBattery()
        {
            if (Counter.Value == 0) return false;
            
            level.ToNextQte();
            Counter.Value--;
            return true;
        }

        public void SetBatteriesAmount(int amount)
        {
            Counter.Value = amount;
        }
    }
}