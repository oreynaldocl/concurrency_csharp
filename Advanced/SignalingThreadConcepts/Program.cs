using System;

namespace SignalingThreadConcepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadSafety.Start();

            Console.ReadKey();
        }
    }
}
