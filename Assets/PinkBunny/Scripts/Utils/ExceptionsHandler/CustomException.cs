using System;

namespace Laphed.Utils.ExceptionsHandler
{
    public abstract class CustomException: Exception
    {
        protected CustomException()
        {
            RaiseException();
        }

        private void RaiseException()
        {
            ExceptionsLogger.Log(GetExceptionText());
        }

        protected abstract string GetExceptionText();
    }
}