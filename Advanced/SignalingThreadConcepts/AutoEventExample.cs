using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalingThreadConcepts
{
    public static class AutoEventExample
    {
        //static EventWaitHandle autoResetEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
        // Same behavior of above line
        static AutoResetEvent eventWaithandler = new AutoResetEvent(false);

        // Aproach used for get elements
        public static void Start()
        {
            Task.Factory.StartNew(WorkerThread);
            Task.Delay(2500).Wait();
            eventWaithandler.Set(); // wake up
        }

        private static void WorkerThread()
        {
            Console.WriteLine($"[{Utils.GetTime()}] Waiting to enter the gate");
            eventWaithandler.WaitOne();
            Console.WriteLine($"[{Utils.GetTime()}] Gate Entered");
        }
    }
}
