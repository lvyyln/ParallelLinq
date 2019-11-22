using System;
using System.Collections.Generic;
using System.Linq;

namespace Example1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Example1();
        }
        public static void Example1() 
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 23, 213, 2, 32, 3, 1, 3, 13, 1, 32, 3, 124, 1, 4, 2, 4, 12, 412, 4, 2, 4, 1, 5, 6, 3, 2, 1, 5, 6, 7, 4, 2, 5, 6, 3, 2, 3, 4, 5, 6, 7, 4, 3, 2 };           
            AsParallel(numbers);
            NotAsParallel(numbers);

        }
        public static void AsParallel(int[] numbers) 
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var parni = numbers.
                AsParallel()
                .Select(n => n)
                .Where(n => n % 2 == 0);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("As Parallel time:{0}", elapsedMs);
        }
        public static void NotAsParallel(int[] numbers) 
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();            
            var parni = numbers
                .Select(n => n)
                .Where(n => n % 2 == 0);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Not As Parallel time:{0}",elapsedMs);
        }
    }
}
