using Laphed.CoroutineProvider;

namespace Laphed.Timer
{
    public class UpdatableTimer: Timer, IUpdatableTimer
    {
        public UpdatableTimer(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }

        public void SetDuration(float newDuration)
        {
            Duration = newDuration;
        }
    }
}