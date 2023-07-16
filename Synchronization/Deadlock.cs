using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    // Example of dead lock
    internal class Deadlock
    {
        static object caztonLock = new object();
        static object anotherLock = new object();

        public static void GenerateNotDeadLock()
        {
            new Thread(() =>
            {
                lock (caztonLock)
                {
                    Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} Cazton Lock obtained");
                    Task.Delay(2000).Wait();
                    lock (anotherLock)
                    {
                        Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} Another Lock obtained");

                    }
                }
            }).Start();

            lock (anotherLock)
            {
                Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} MAIN THREAD Another Lock obtained");
            }
        }

        public static void GenerateDeadLock()
        {
            new Thread(() =>
            {
                lock (caztonLock)
                {
                    Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} Cazton Lock obtained");
                    Task.Delay(2000).Wait();
                    lock (anotherLock) // wait until anotherLock from 54 is realeased
                    {
                        Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} Another Lock obtained");

                    }
                }
            }).Start();

            lock (anotherLock)
            {
                Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} MAIN THREAD Another Lock obtained");
                Task.Delay(1000).Wait();
                lock (caztonLock) // wait until caztonLock from 43 is realeased
                {
                    Console.WriteLine($"{DateTime.UtcNow.GetTimeString()} MAIN THREAD cazton Lock obtained");
                }
            }
        }

    }
}
