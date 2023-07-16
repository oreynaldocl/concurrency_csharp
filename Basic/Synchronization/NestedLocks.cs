using System;
using System.Threading.Tasks;

namespace Synchronization
{
    public class NestedLocks
    {
        static object caztonLock = new object();

        public static void Nested()
        {
            lock (caztonLock)
            { // Lock for resource caztonLock start here
                DoSomething();
            } // Only one lock is released here, the lock of line 16
        }

        private static void DoSomething()
        {
            lock (caztonLock) // if called from Nested, don't generate a lock
            {
                Task.Delay(1000).Wait();
                AnotherMethod();
            }
        }

        private static void AnotherMethod()
        {
            lock (caztonLock) // if called from method that locks caztonLock, don't generate a new lock
            {
                Console.WriteLine("Just finishing");
            }
        }
    }
}
