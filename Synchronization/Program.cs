using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synchronization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UseMonitor();

            //Deadlock.GenerateNotDeadLock();
            //Deadlock.GenerateDeadLock();

            //ReadWriterLock.Start();

            MutexExample.Start();

            Console.ReadKey();
        }

        static async void UseMonitor()
        {
            Account account = new Account(30000);
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                await Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Starting {i} #################");
                    account.WithdrawRandomly();
                    Console.WriteLine($"Finished {i} #################");
                });
            }
            Task.WaitAll(Task.FromResult(0));
        }
    }
}
