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
                Thread thread = new Thread(AcquireWaitMutex);
                thread.Name = $"Thread{i}";
                thread.Start();
            }
        }

        private static void AcquireWaitMutex()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false)) {
                Console.WriteLine($"Mutex CAN'T BE ACQUIRE {Thread.CurrentThread.Name}");
                return;
            }
            DoSomething();
            mutex.ReleaseMutex();
            Console.WriteLine($"Mutex releases by {Thread.CurrentThread.Name}");
        }

        private static void AcquireMutex()
        {
            mutex.WaitOne(); // Wait until the mutex is release
            DoSomething();
            mutex.ReleaseMutex();
            Console.WriteLine($"Mutex releases by {Thread.CurrentThread.Name}");
        }

        private static void DoSomething()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine($"Mutex acquired by {Thread.CurrentThread.Name}");
        }
    }
}
