using Laphed.CoroutinesProvider;
using Zenject;

namespace Laphed.Timer
{
    public class UpdatableTimerFactory: TimerFactoryBase, IFactory<IUpdatableTimer>
    {
        [Inject]
        public UpdatableTimerFactory(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }

        public IUpdatableTimer Create()
        {
            return new UpdatableTimer(coroutineProvider);
        }
    }
}