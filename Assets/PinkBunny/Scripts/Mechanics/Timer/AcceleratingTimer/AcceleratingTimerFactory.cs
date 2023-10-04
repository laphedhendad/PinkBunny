using Laphed.CoroutineProvider;
using Zenject;

namespace Laphed.Timer
{
    public class AcceleratingTimerFactory: TimerFactoryBase, IFactory<IAcceleratingTimer>
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