using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomValue = 0;
            int maxRandomValue = 100;
            int numder;
            int sumOfNumbers = 0;
            int numberToCheck = 3;
            int numberToCheck2 = 5;

            numder = random.Next(minRandomValue, maxRandomValue);
            Console.WriteLine(numder);

            for (int i = 0; i <= numder; i++)
            {
                if ((i % numberToCheck == 0) || (i % numberToCheck2 == 0))
                {
                    sumOfNumbers = sumOfNumbers + i;   
                }
            }

            Console.WriteLine(sumOfNumbers);
        }
    }
}
