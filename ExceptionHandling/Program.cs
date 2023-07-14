using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UnhandledException();

            HandledException();
            Console.ReadKey();
        }

        private static void UnhandledException()
        {
            try
            {
                // Main thread can catch the error
                Execute();
                // exception not catpured by try/catch of main thread
                //new Thread(Execute).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void Execute()
        {
            throw null;
        }

        private static void HandledException()
        {
            // Main catches the exception
            TryExecute();
            // Thread catches the exception
            new Thread(TryExecute).Start();
        }

        private static void TryExecute()
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
