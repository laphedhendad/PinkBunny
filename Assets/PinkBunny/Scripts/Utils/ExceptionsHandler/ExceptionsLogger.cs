using UnityEngine;

namespace Laphed.Utils.ExceptionsHandler
{
    public static class ExceptionsLogger
    {
        public static void Log(string exceptionText)
        {
            Debug.LogError(exceptionText);
        }
    }
}