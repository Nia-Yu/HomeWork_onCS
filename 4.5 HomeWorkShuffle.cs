using System;

namespace HWShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[9];

            FillArray(array);
            Console.WriteLine("Начальный массив");
            OutputArray(array);

            ShuffleArray(array);
            Console.WriteLine("\nПеремешанный массив");
            OutputArray(array);
        }

        static void FillArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
            }
        }

        static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int randomElement = random.Next(i);
                int shuffledElement = array[randomElement];
                array[randomElement] = array[i];
                array[i] = shuffledElement;
            }
        }
    }
}
