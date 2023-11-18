namespace Laphed.ExceptionsHandler
{
    public class StartNotInitializedTimerException: CustomException
    {
        protected override string GetExceptionText()
        {
            return $"{typeof(StartNotInitializedTimerException)}: Set Timer.Duration property before invoking it's Start() method.";
        }
    }
}