using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelExamples
{
    internal class Cancellation
    {
        public static void Start(int waitTIme, int cancellationTime)
        {
            var source = new CancellationTokenSource();
            var myTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    WaitSmallPeriod(waitTIme, source.Token);
                    //source.
                    ExecuteATask(source.Token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("It was canceled before finishing");
                }
            });
            Task.Delay(cancellationTime).Wait();
            Console.WriteLine($"IsCanceled: {myTask.IsCanceled} IsCompleted: {myTask.IsCompleted}. Status: {myTask.Status}");
            source.Cancel();

            Console.WriteLine($"IsCanceled: {myTask.IsCanceled} IsCompleted: {myTask.IsCompleted}. Status: {myTask.Status}");

        }
        private static void ExecuteATask(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                Console.WriteLine($"Time was finished EXECUTING A TASK");
            }
            else {
                Console.WriteLine($"IT WAS CANCELED");
            }
        }

        private static void WaitSmallPeriod(int v, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            Task.Delay(v).Wait();
        }
    }
}
