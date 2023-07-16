using System;
using System.Threading.Tasks;

namespace TaskDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Review if we can join tasks in a thread
            // One task that wait
            Task<string> antecendt = Task.Run(() => DateTime.UtcNow.ToLongDateString());
            // one task that calls to X function
            Task<string> continuation = antecendt.ContinueWith(x => $"Today is {antecendt.Result}");
            Console.WriteLine(continuation.Result);

            Console.ReadKey();  
        }
    }
}
