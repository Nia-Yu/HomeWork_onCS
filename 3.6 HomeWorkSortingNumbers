using System;

namespace HWSortingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fIrstArray = { 1, 5, 9, 7, 4, 8, 6, 2, 3, 15 };
            int[] secondArray = new int[fIrstArray.Length];
            int maxElement = 0;
            int idElement = 0;

            for(int i = 0; i < fIrstArray.Length; i++)
            {
                Console.Write($"{fIrstArray[i]} ");
            }

            Console.WriteLine("");

            for (int i = fIrstArray.Length; i > 0; i--)
            {
                for (int j = 0; j < fIrstArray.Length; j++)
                {
                    if (maxElement <= fIrstArray[j])
                    {
                        maxElement = fIrstArray[j];
                        idElement = j;
                    }
                }
                fIrstArray[idElement] = 0;
                secondArray[i - 1] = maxElement;
                maxElement = 0;
            }

            Console.WriteLine("");

            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write($"{secondArray[i]} ");
            }
        }
    }
}
