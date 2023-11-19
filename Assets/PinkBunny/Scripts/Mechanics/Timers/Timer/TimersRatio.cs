namespace Laphed.Timers
{
    public static class TimersRatio
    {
        private static int milliseconds = 16;
        public static int Milliseconds
        {
            get => milliseconds;
            set
            {
                milliseconds = value;
                seconds = value / 1000f;
            }
        }
        
        private static float seconds = 0.016f;

        public static float Seconds
        {
            get => seconds;
            set
            {
                seconds = value;
                milliseconds = (int)(value * 1000);
            }
        }
    }
}