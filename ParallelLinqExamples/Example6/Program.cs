using System;
using System.Collections.Generic;
using System.Linq;

namespace Example6
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 23, 213, 2, 32, 3, 1, 3, 13, 1, 32, 3, 124, 1, 4, 2, 4, 12, 412, 4, 2, 4, 1, 5, 6, 3, 2, 1, 5, 6, 7, 4, 2, 5, 6, 3, 2, 3, 4, 5, 6, 7, 4, 3, 2 };

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            IEnumerable<int> auto2 = numbers
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Where(p => p % 2 == 0)
                .Select(p => p);

            watch2.Stop();

            var elapsedMs2 = watch2.ElapsedTicks;
            Console.WriteLine(" Time :{0}",elapsedMs2);
        }
    }
}
