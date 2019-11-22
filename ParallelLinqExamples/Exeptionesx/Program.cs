using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exeptionesx
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
                              "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

            IEnumerable<string> auto = cars
                .AsParallel()
                .Select(p =>
                {
                    if (p == "Aston Martin" || p == "Ford")
                        throw new Exception("Проблемы с машиной " + p);
                    return p;
                });

            try
            {
                foreach (string s in auto)
                    Console.WriteLine("Результат: " + s + "\n");
            }
            catch (AggregateException agex)
            {
                agex.Handle(ex =>
                {
                    Console.WriteLine(ex.Message);
                    return true;
                });
            }
        }
        
    }
}
