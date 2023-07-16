using System;

namespace Synchronization
{
    public static class Extensions
    {
        public static string GetTimeString(this DateTime time)
        {
            return time.ToString("hh:mm:ss.fff");
        }
    }
}
