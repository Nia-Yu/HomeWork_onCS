using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWDegreeOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minRandomValue = 2;
            int maxRandomValue = 20;
            int numder;
            int digit = 2;
            int degreeOfDigit = 1;
            int digitToDegreeOf = 2;

            numder = random.Next(minRandomValue, maxRandomValue);
            Console.WriteLine(numder);

            while (digitToDegreeOf <= numder)
            {
                digitToDegreeOf *= digit;
                degreeOfDigit += 1;
            }
            
            Console.WriteLine(degreeOfDigit);
            Console.WriteLine(digitToDegreeOf);
        }
    }
}
