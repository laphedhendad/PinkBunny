using Laphed.Utils.CoroutineProvider;
using Zenject;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public class TimerFactory: ITimerFactory<IUpdatableTimer>, ITimerFactory<IAcceleratingTimer>
    {
        private readonly ICoroutineProvider coroutineProvider;

        [Inject]
        public TimerFactory(ICoroutineProvider coroutineProvider)
        {
            this.coroutineProvider = coroutineProvider;
        }
        
        IUpdatableTimer ITimerFactory<IUpdatableTimer>.Create()
        {
            return new UpdatableTimer(coroutineProvider);
        }

        IAcceleratingTimer ITimerFactory<IAcceleratingTimer>.Create()
        {
            return new AcceleratingTimer(coroutineProvider);
        }
    }
}