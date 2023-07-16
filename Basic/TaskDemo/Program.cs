using System;
using System.Threading.Tasks;

namespace TaskDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Review if we can join tasks in a thread
            // One task that wait
            Task<string> antecendt = Task.Run(async () =>
            {
                Console.WriteLine($"{GetCurrentTime()} Building the required string");
                await Task.Delay(2000);
                return DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
            });
            //delay.
            var continuation = antecendt.ContinueWith((completed) =>
            {
                Console.WriteLine($"{GetCurrentTime()} Enter to continuation IsCompleted: {completed.IsCompleted}");
                return $"Today is {completed.Result}";
            });
            Console.WriteLine($"{GetCurrentTime()} waiting for result {continuation.Result}");
/*Result:
08:20:25.254 Building the required string                               // (2)
08:20:27.261 Enter to continuation IsCompleted: True                    // (3)
08:20:25.222 waiting for result Today is 07/16/2023 08:20:27.261 PM     // (1)
*/

            Console.ReadKey();
        }
        static string GetCurrentTime()
        {
            return DateTime.UtcNow.ToString("hh:mm:ss.fff");
        }
    }
}
/* TODO Needs to be reviewed if can join Delays with execution. And if delay can be aborted
// one task that calls to X function
var delay = Task.Delay(2500);
var continuation = delay.ContinueWith((previous) => {
    Console.WriteLine($"{GetCurrentTime()} After V1 wait {previous.IsCompleted}");
    return antecendt.ContinueWith(x => $"Today is {x.Result}");
});
Console.WriteLine($"{GetCurrentTime()} waiting 2 results {continuation.Result.Result}");
*/
