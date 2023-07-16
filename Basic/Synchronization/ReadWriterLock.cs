using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    public static class ReadWriterLock
    {
        static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
        static Dictionary<int, string> persons = new Dictionary<int, string>();
        static Random random = new Random();

        public static void Start()
        {
            var task1 = Task.Factory.StartNew(Read, "01Reader");
            var task2 = Task.Factory.StartNew(Write, "1st");
            var task3 = Task.Factory.StartNew(Write, "2nd");
            var task4 = Task.Factory.StartNew(Read, "02Reader");
            var task5 = Task.Factory.StartNew(Read, "03Reader");
            Task.WaitAll(task1, task2, task3, task4, task5);
        }

        static void Read(object readId)
        {
            int dictPos = 0;
            for (int i = 0; i < 10; i++) {
                readerWriterLockSlim.EnterReadLock();
                Thread.Sleep(100);
                if (persons.Count > dictPos) {
                    var key = persons.Keys.ElementAtOrDefault(dictPos);
                    Console.WriteLine($"[{readId}-{i}] Pos:{dictPos} = {persons[key]}");
                    dictPos++;
                }
                readerWriterLockSlim.ExitReadLock();
            }
        }
        static void Write(object threadId)
        {
            for (int i = 0; i < 10; i++)
            {
                //int id = random.Next(200, 5000); Not thread safe
                int id = GetRandom();
                readerWriterLockSlim.EnterWriteLock();
                string person = $"Person{i} - {id}";
                persons.Add(id, person);
                readerWriterLockSlim.ExitWriteLock();
                Console.WriteLine($"[{threadId}] added {person}");
                Thread.Sleep(250);
            }
        }

        private static int GetRandom()
        {
            lock (random) {
                return random.Next(200, 5000);
            }
        }
    }
}
