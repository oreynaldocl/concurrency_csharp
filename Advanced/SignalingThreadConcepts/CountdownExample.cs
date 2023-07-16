using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalingThreadConcepts
{
    internal class CountdownExample
    {
        static CountdownEvent countEvent = new CountdownEvent(5);
        public static void Start()
        {
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);
            Task.Factory.StartNew(DoSomething);

            countEvent.Wait();
            Console.WriteLine($"[{Utils.GetTime()}] Count event was called");
        }

        private static void DoSomething()
        {
            Task.Delay(250).Wait();
            Console.WriteLine($"[{Utils.GetTime()}]-{Task.CurrentId} called the signal.");
            countEvent.Signal();

        }
    }
}
