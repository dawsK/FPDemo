using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsharpDemoCSharp
{
    static class IntExtensions
    {
        public static bool ContainsNumber(this int value, int num)
        {
            return value.ToString().Contains(num.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i%3 == 0 || i.ContainsNumber(3))
                {
                    Console.WriteLine("Fizz");
                }
                else if (i%5 == 0 || i.ContainsNumber(5))
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
