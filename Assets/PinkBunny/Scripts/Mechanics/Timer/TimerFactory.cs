using Laphed.CoroutineProvider;
using Zenject;

namespace Laphed.Timer
{
    public class TimerFactory: TimerFactoryBase, ITimerFactory<ITimer>
    {
        [Inject]
        public TimerFactory(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }
        
        public ITimer Create()
        {
            return new Timer(coroutineProvider);
        }

    }
}