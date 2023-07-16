using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalingThreadConcepts
{
    public static class TwoWaySignaling
    {
        static EventWaitHandle first = new AutoResetEvent(false);
        static EventWaitHandle second = new AutoResetEvent(false);
        static object caztonLock = new object();
        static string value = "";

        public static void Start()
        {
            CancellationToken cancel = new CancellationToken();
            var t = Task.Factory.StartNew(WorkerThread, cancel);
            // TODO Review how cancel a task
            Console.WriteLine($"[{Utils.GetTime()}] Main thread is waiting");
            first.WaitOne();

            lock (caztonLock)
            {
                value = $"[{Utils.GetTime()}] Updated value from MAIN thread";
                Console.WriteLine(value);
            }
            Task.Delay(3000).Wait();
            second.Set();
            Console.WriteLine($"[{Utils.GetTime()}] MAIN Thread is finished");
        }

        private static void WorkerThread()
        {
            Task.Delay(1000).Wait();
            lock (caztonLock)
            {
                value = $"[{Utils.GetTime()}] Updated value from worker";
                Console.WriteLine(value);
            }
            first.Set();
            Console.WriteLine($"[{Utils.GetTime()}] Release MAIN thread");


            Console.WriteLine($"[{Utils.GetTime()}] Worker Thread is waiting");
            second.WaitOne();
            Console.WriteLine($"[{Utils.GetTime()}] Worker Thread is finished");
        }
    }
}
