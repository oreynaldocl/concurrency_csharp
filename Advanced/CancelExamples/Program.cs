using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancelExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cancellation.Start(2000, 3000);
            //Cancellation.Start(3000, 2000);

            CancelContinue.CallingCancellation();

            Console.WriteLine("Just finished before tasks");
            Console.ReadKey();
        }

    }
}
