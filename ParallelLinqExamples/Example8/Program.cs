using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Example8
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource(50);
            try
            {
                int[] numbers = Enumerable.Range(0, 100).ToArray();
                var factorials = from n in numbers.AsParallel()
                                 .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                                 .WithCancellation(cts.Token)
                                 select Factorial(n);
                foreach (var n in factorials)
                    Console.WriteLine(n);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Operation was canceled");
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions != null)
                {
                    foreach (Exception e in ex.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }
            Console.ReadLine();
        }

        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {x} = {result}");
            return result;
        }
    }
}
