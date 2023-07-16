using System;
using System.Threading;

namespace SharedResources
{
    internal class Program
    {
        private static bool isCompleted = false;
        static readonly object lockCompleted = new object();

        static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);
            thread.Start();

            // Main thread
            HelloWorld();
        }

        private static void HelloWorld()
        {
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    // isCompleted = true; // Adding here log once, but probably it can be reached by one ghread
                    Console.WriteLine($"Hello World should print only once.");
                    isCompleted = true;
                }
            }
        }
    }
}
