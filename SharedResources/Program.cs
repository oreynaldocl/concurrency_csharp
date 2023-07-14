using System;
using System.Threading;

namespace SharedResources
{
    internal class Program
    {
        private static bool isCompleted = false;

        static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);
            thread.Start();

            // Main thread
            HelloWorld();
        }

        private static void HelloWorld()
        {
            if (!isCompleted)
            {
                // Log repeated twice because for each thread the `isCompleted` is false.
                Console.WriteLine("Hello World should print only once.");
                isCompleted = true;
            }
        }
    }
}
