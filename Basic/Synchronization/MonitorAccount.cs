using System;
using System.Threading;

namespace Synchronization
{
    internal class Account
    {
        int balance;
        object caztonLock = new object();
        Random random = new Random(DateTime.UtcNow.Second);

        public int Balance => balance;

        public Account(int initialBalance)
        {
            balance = initialBalance;
        }

        int WithDraw(int amount)
        {
            if (balance == 0)
            {
                throw new Exception("Not enough balance1");
            }
            //lock (caztonLock) { } similar approach, but braces {} will describe the moment is unlock.

            Monitor.Enter(caztonLock);
            try
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"Amount drawn: {amount}");
                    balance -= amount;
                    return balance;
                }
                else {
                    Console.WriteLine($"Not possible to draw: {amount}");
                }
            }
            finally
            {
                Monitor.Exit(caztonLock);
            }

            return balance ;
        }

        public void WithdrawRandomly()
        {
            for (int i = 0; i < 10; i++) {
                int toWithdraw = random.Next(100, 1000);
                int balance = WithDraw(toWithdraw);
                Console.WriteLine($"[{i}] Current balance {balance}");
            }
        }
    }
}
