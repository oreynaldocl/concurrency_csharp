using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalingThreadConcepts
{
    internal static class ManualResetEventExample
    {
        static EventWaitHandle waitEvent = new ManualResetEvent(false);
        // Same as above
        //static EventWaitHandle first = new EventWaitHandle(false, EventResetMode.ManualReset);

        public static void Start()
        {
            StartThreads();

            Task.Delay(1000).Wait();
            LogReadKey($"[{Utils.GetTime()}] Press a key to RELEASE all threads");
            waitEvent.Set();

            Task.Delay(1000).Wait();
            LogReadKey($"[{Utils.GetTime()}] Press a key. No Thread won't wait the signal. It is not reset");
            StartThreads();
            waitEvent.Set();

            Task.Delay(1000).Wait();

            waitEvent.Reset();
            LogReadKey($"[{Utils.GetTime()}] Press a key. Now the task will be wait");
            Task.Delay(1000).Wait();
            StartThreads();
            LogReadKey($"[{Utils.GetTime()}] Press a key. To finally release the last of them");
            waitEvent.Set();
        }

        private static void LogReadKey(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private static void StartThreads()
        {
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
            Task.Factory.StartNew(CallWaitOne);
        }

        private static void CallWaitOne()
        {
            Console.WriteLine($"[{Utils.GetTime()}]-{Task.CurrentId} has called WaitOne");
            waitEvent.WaitOne();
            Console.WriteLine($"[{Utils.GetTime()}]-{Task.CurrentId} finally ended");
        }
    }
}
