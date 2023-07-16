using System;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int workerThreads = 0;
            int completitionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completitionPortThreads);

            int processCount = Environment.ProcessorCount;
            Console.WriteLine($"Process: {processCount} ThreadPool?:{Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"MinWorkThread: {workerThreads} MinCompletition: {completitionPortThreads}");
            ThreadPool.GetMaxThreads(out workerThreads, out completitionPortThreads);
            Console.WriteLine($"MaxWorkThread: {workerThreads} MaxCompletition: {completitionPortThreads}");

            Employee employee = new Employee() { Name = "Oscar", CompanyName = "Owner" };
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(DisplayEmployeeInfo), employee);

            Console.ReadKey();
        }

        private static void DisplayEmployeeInfo(object state)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Employee employee = (Employee)state;
            Console.WriteLine($"Name: {employee.Name} and company name: {employee.CompanyName}");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
}
