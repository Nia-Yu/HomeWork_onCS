using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWMultiplesNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomValue = 1;
            int maxRandomValue = 28;
            int numder;
            int counter = 0;
            int minValueMultipleNumder = 99;
            int maxValueMultipleNumder = 1000;

            numder = random.Next(minRandomValue, maxRandomValue);
            Console.WriteLine(numder);

            for (int i = numder; i < maxValueMultipleNumder; i += numder)
            {
                if  (i > minValueMultipleNumder)
                {
                    counter += 1;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
