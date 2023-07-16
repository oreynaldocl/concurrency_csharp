using System;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    public static class MutexExample
    {
        static Mutex mutex = new Mutex();
        public static void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(AcquireMutex);
                thread.Name = $"Thread{i}";
                thread.Start();
            }
        }

        private static void AcquireMutex()
        {
            mutex.WaitOne();
            DoSomething();
            mutex.ReleaseMutex();
            Console.WriteLine($"Mutext releases by {Thread.CurrentThread.Name}");
        }

        private static void DoSomething()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine($"Mutext acquired by {Thread.CurrentThread.Name}");
        }
    }
}
