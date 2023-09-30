using Laphed.Utils.CoroutineProvider;

namespace Laphed.Mechanics.AcceleratingTimer
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