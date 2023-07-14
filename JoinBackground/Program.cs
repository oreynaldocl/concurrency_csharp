using System;
using System.Threading;

namespace JoinBackground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintHelloWorld);
            thread.IsBackground = true; // Not sure what does
            thread.Start();
            thread.Join(); // makes the current thread wait until this is executed

            Console.WriteLine("Hello");
            Console.ReadKey();
        }

        private static void PrintHelloWorld()
        {
            Console.WriteLine($"Hello WORLDDDDD!!!! {Thread.CurrentThread.IsBackground}");
            Thread.Sleep(5000);
        }
    }
}
