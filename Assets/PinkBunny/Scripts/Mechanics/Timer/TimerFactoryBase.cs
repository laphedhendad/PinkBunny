using Laphed.Utils.CoroutineProvider;

namespace Laphed.Mechanics.Timer
{
    public abstract class TimerFactoryBase
    {
        protected readonly ICoroutineProvider coroutineProvider;

        protected TimerFactoryBase(ICoroutineProvider coroutineProvider)
        {
            this.coroutineProvider = coroutineProvider;
        }
    }
}