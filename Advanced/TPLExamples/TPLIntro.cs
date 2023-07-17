using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPLExamples
{
    internal class TPLIntro
    {
        public static void Start()
        {
            Stopwatch time = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write($"{i}-");
            }
            Console.WriteLine($"\n{time.ElapsedMilliseconds}ms Finished normal for");

            time.Stop();
            time.Start();

            Parallel.For(0, 1000, i => Console.Write($"{i}-"));
            Console.WriteLine($"\n{time.ElapsedMilliseconds}ms Finished Parallel for");
        }
    }
}
