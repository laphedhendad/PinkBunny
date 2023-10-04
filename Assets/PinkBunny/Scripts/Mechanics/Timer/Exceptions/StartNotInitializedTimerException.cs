namespace Laphed.ExceptionsHandler
{
    public class StartNotInitializedTimerException: CustomException
    {
        protected override string GetExceptionText()
        {
            return $"{typeof(StartNotInitializedTimerException)}: Initialize timer before invoking it's Start() method.";
        }
    }
}