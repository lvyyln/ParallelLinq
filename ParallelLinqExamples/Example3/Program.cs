using System;
using System.Collections.Generic;
using System.Linq;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 23, 213, 2, 32, 3, 1, 3, 13, 1, 32, 3, 124, 1, 4, 2, 4, 12, 412, 4, 2, 4, 1, 5, 6, 3, 2, 1, 5, 6, 7, 4, 2, 5, 6, 3, 2, 3, 4, 5, 6, 7, 4, 3, 2 };

            Console.WriteLine("AsSequential");

            var something = numbers
                .AsParallel()
                .AsOrdered()
                .Take(15)
                .AsSequential()
                .Take(10);


            foreach (int num in something)
            {
                Console.WriteLine(num);
            }
        }
    }
}
