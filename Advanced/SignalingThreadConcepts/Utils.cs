using System;

namespace SignalingThreadConcepts
{
    public static class Utils
    {
        public static string GetTime()
        {
            return DateTime.UtcNow.ToString("hh:mm:ss.fff");
        }
    }
}
