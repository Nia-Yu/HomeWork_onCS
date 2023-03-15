using System;

namespace HWTwo_DimensionalArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { { 2, 5, 4, 8, 6 }, { 1, 5, 7, 8, 9 }, { 8, 4, 6, 7, 8 } };
            int sum = 0;
            int multiplication = 1;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[1, i];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                multiplication *= array[i, 0];
            }


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();

            }

            Console.WriteLine(sum);
            Console.WriteLine(multiplication);
        }
    }
}
