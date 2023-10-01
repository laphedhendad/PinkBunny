namespace Laphed.ExceptionsHandler
{
    public class ContinueNotStartedTimerException: CustomException
    {
        protected override string GetExceptionText()
        {
            return $"{typeof(ContinueNotStartedTimerException)}: Try to invoke Continue method on not started timer.";
        }
    }
}