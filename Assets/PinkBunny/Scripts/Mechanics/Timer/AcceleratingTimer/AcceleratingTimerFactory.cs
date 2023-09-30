using Laphed.Utils.CoroutineProvider;
using Zenject;

namespace Laphed.Mechanics.Timer
{
    public class AcceleratingTimerFactory: TimerFactoryBase, ITimerFactory<IAcceleratingTimer>
    {
        [Inject]
        public AcceleratingTimerFactory(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }

        public IAcceleratingTimer Create()
        {
            return new AcceleratingTimer(coroutineProvider);
        }
    }
}