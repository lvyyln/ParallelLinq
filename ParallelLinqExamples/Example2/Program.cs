using System;
using System.Collections.Generic;
using System.Linq;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21,22, 23, 24, 25, 26, 124, 1, 4, 2, 4, 12, 412, 4, 2, 4, 1, 5, 6, 3, 2, 1, 5, 6, 7, 4, 2, 5, 6, 3, 2, 3, 4, 5, 6, 7, 4, 3, 2 };
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var something = numbers
                .AsParallel()
                .AsUnordered();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("time:{0}", elapsedMs);
            foreach (int num in something) 
            {
                Console.WriteLine(num);
            }

        }
    }
}
