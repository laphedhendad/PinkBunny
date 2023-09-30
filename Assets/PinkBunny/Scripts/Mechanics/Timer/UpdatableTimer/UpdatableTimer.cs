using Laphed.Utils.CoroutineProvider;

namespace Laphed.Mechanics.Timer
{
    public class UpdatableTimer: Timer, IUpdatableTimer
    {
        public UpdatableTimer(ICoroutineProvider coroutineProvider) : base(coroutineProvider)
        {
        }

        public void SetDuration(float newDuration)
        {
            duration = newDuration;
        }
    }
}