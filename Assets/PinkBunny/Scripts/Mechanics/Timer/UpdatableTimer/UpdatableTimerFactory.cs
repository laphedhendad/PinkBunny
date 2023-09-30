using Laphed.Utils.CoroutineProvider;
using Zenject;

namespace Laphed.Mechanics.Timer
{
    public class UpdatableTimerFactory: TimerFactoryBase, ITimerFactory<IUpdatableTimer>
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