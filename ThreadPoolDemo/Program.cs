using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

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
