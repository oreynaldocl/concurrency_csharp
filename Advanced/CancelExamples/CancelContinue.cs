using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancelExamples
{
    internal class CancelContinue
    {
        public static void ReviewContinuation()
        {
            Task task = Task.Run(() =>
            {
                Task.Delay(5000).Wait();
                Console.WriteLine($"{Task.CurrentId} First task finished");
            });
            Task task2 = task.ContinueWith((prevTask) =>
            {
                Console.WriteLine($"PREV IsCompleted: {prevTask.IsCompleted} IsCanceled: {prevTask.IsCanceled}");
                Console.WriteLine($"{Task.CurrentId} Second task finished");
            });

            Task.Factory.StartNew(() =>
            {
                task2.Wait();
            });
        }

        public static void CallingCancellation()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            Task task = Task.Run(() =>
            {
                source.Token.ThrowIfCancellationRequested();
                Task.Delay(5000).Wait();
                source.Token.ThrowIfCancellationRequested();
                Console.WriteLine($"{Task.CurrentId} First task finished");
                return Task.CompletedTask;
            }, source.Token);
            Task task2 = task.ContinueWith((prevTask) =>
            {
                Console.WriteLine($"PREV IsCompleted: {prevTask.IsCompleted} IsCanceled: {prevTask.IsCanceled}. requested: {source.Token.IsCancellationRequested}");
                Console.WriteLine($"{Task.CurrentId} Second task finished");
            });

            Task.Factory.StartNew(() =>
            {
                try
                {
                    task2.Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error happens {0}", ex.Message);
                }
            });

            Task.Delay(10000).Wait();
            source.Cancel();
            Console.WriteLine($"review token is cancelled: {source.Token.IsCancellationRequested}");
        }
    }
}
