using Laphed.Utils.CoroutineProvider;
using Zenject;

namespace Laphed.Mechanics.AcceleratingTimer
{
    public class TimerFactory: ITimerFactory<ITimer>, ITimerFactory<IAcceleratingTimer>
    {
        private readonly ICoroutineProvider coroutineProvider;

        [Inject]
        public TimerFactory(ICoroutineProvider coroutineProvider)
        {
            this.coroutineProvider = coroutineProvider;
        }
        
        ITimer ITimerFactory<ITimer>.Create()
        {
            return new Timer(coroutineProvider);
        }

        IAcceleratingTimer ITimerFactory<IAcceleratingTimer>.Create()
        {
            return new AcceleratingTimer(coroutineProvider);
        }
    }
}