using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Example5
{
    //Значение NotBuffered заставляет каждый результирующий элемент передаваться по мере получения.
    //Значение FullBuffered обеспечивает ожидание, пока все результаты не будут получены, прежде чем передавать их потребителю.
    //Значение AutoBuffered позволяет системе выбирать размер буфера и передавать элементы по мере наполнения буфера. 
    //Последнее из значений перечисления — Default — это то же самое, что и AutoBuffered.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            IEnumerable<int> results = Enumerable.Range(0, 20)
                .AsParallel()
                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Select(i =>
                {
                    System.Threading.Thread.Sleep(2000);
                    return i;
                });

            Console.WriteLine("End");

            Stopwatch sw = Stopwatch.StartNew();

            foreach (int i in results)
            {
                Console.WriteLine("Значение: {0}, Время: {1}", i, sw.ElapsedMilliseconds);
            }
        }
    }
}
