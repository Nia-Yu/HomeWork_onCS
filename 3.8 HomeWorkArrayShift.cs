using System;

namespace HWArrayShift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int lengthArray = array.Length;
            int numberShifts = 0;

            Console.WriteLine("Исходный массив");

            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }

            Console.Write("\nВведите число сдвигов влево: ");
            numberShifts = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberShifts; i++)
            {
                int firstNumber = array[0];

                for (int j = 0; j < lengthArray - 1; j++)
                {
                    array[j] = array[j+1];
                }

                array[lengthArray - 1] = firstNumber;
            }

            Console.WriteLine("Новый массив");

            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
