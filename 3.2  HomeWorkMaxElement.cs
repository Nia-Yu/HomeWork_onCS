using System;

namespace HWMaxElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            Random random = new Random();
            int minMeaningRamdom = 1;
            int maxMeaningRamdom = 18;
            int maxElement = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minMeaningRamdom, maxMeaningRamdom);
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine("");
            }
            
            foreach (int element in array)
            {
                if (maxElement <= element)
                {
                    maxElement = element;
                }
            }

            Console.WriteLine($"\n{maxElement}\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxElement)
                    {
                        array[i, j] = 0;
                    }
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
