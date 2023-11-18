namespace Laphed.ExceptionsHandler
{
    public class ContinueNotStoppedTimerException: CustomException
    {
        protected override string GetExceptionText()
        {
            return $"{typeof(ContinueNotStoppedTimerException)}: Try to invoke Continue method on started but not stopped timer.";
        }
    }
}