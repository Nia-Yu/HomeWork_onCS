using System;

namespace HWLocalMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();
            int minMeaningRamdom = 0;
            int maxMeaningRamdom = 9;
            int localMax;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minMeaningRamdom, maxMeaningRamdom);
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();

            if (array[0] > array[1])
            {
                localMax = array[0];
                Console.WriteLine(localMax);
            }

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1] && array[i] > array[i - 1])
                {
                    localMax = array[i];
                    Console.WriteLine(localMax);
                }
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                localMax = array[array.Length - 1];
                Console.WriteLine(localMax);
            }
        }
    }
}
