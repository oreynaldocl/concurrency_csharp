using System;
using System.Threading;

namespace Synchronization
{
    // Resource - intense
    public static class SemaphoreExample
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);

        public static void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(EnterSemaphore).Start(i + 1);
            }
        }

        private static void EnterSemaphore(object id)
        {
            Console.WriteLine($"[{id}] is waiting to be part of club.");
            semaphoreSlim.Wait();
            Console.WriteLine($"[{id}] part of club.");
            Thread.Sleep(1000 / (int)id);
            Console.WriteLine($"[{id}] LEFT the club ######.");
        }
    }
}
