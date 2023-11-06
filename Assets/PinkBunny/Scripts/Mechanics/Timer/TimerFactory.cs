using Laphed.CoroutinesProvider;
using Zenject;

namespace Laphed.Timer
{
    public class TimerFactory: TimerFactoryBase, IFactory<ITimer>
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