using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalingThreadConcepts
{
    public static class ThreadSafety
    {
        static Dictionary<int, string> items = new Dictionary<int, string>();
        public static void Start()
        {
            Task.WaitAll(
                Task.Factory.StartNew(AddItem),
                Task.Factory.StartNew(AddItem),
                Task.Factory.StartNew(AddItem),
                Task.Factory.StartNew(AddItem),
                Task.Factory.StartNew(AddItem)
            );
        }

        private static void AddItem()
        {
            lock (items)
            {
                Console.WriteLine($"[{Task.CurrentId}] Lock acquire adding Person {items.Count}");
                items.Add(items.Count, $"Person {items.Count}");
            }
            Dictionary<int, string> read;
            lock (items)
            {
                read = new Dictionary<int, string>(items);
            }
            foreach (var item in read)
            {
                Console.WriteLine($"[{Task.CurrentId}] {item.Key} - {item.Value}");
            }
        }

    }
}
