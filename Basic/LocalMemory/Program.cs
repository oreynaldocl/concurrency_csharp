using System;
using System.Threading;

namespace LocalMemory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Thread(Print1To100).Start();

            Print1To100();
        }

        private static void Print1To100()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{i + 1} ");
            }
            Console.WriteLine("");
        }
    }
}
