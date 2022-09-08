using System;

namespace HWSubarrayrRepetitions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();
            int minMeaningRamdom = 8;
            int maxMeaningRamdom = 10;
            int repeatNumber = 0;
            int numberRepetitions = 0;
            int quantity = 1;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minMeaningRamdom, maxMeaningRamdom);
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    quantity++;
                }
                else if (numberRepetitions < quantity)
                {
                    numberRepetitions = quantity;
                    repeatNumber = array[i-1];
                    quantity = 1;
                }
                else
                {
                    quantity = 1;
                }
            }

            Console.WriteLine($"Число {repeatNumber} повторяется {numberRepetitions} раз подряд");
        }
    }
}
