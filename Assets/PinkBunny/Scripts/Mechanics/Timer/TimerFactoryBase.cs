using Laphed.CoroutineProvider;

namespace Laphed.Timer
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