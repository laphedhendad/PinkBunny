using Laphed.Utils.CoroutineProvider;
using Zenject;

namespace Laphed.Mechanics.Timer
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