namespace Laphed.ExceptionsHandler
{
    public class UpdateActiveTimerDurationException: CustomException
    {
        protected override string GetExceptionText()
        {
            return $"{typeof(UpdateActiveTimerDurationException)}: Try to update duration of ticked timer. Call ITimer.Stop() before duration update.";
        }
    }
}