using System;

namespace HWDynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthArray = 0;
            int[] array = new int[lengthArray];
            int number;
            string message = "";
            string messageSum = "sum";
            string messageExit = "exit";

            while (message != messageExit)
            {
                Console.WriteLine($"Введите число, {messageExit} или {messageSum}: ");
                message = Console.ReadLine();

                if (message != messageSum && message != messageExit)
                {
                    number = Convert.ToInt32(message);
                    lengthArray += 1;
                    int[] tempArray = new int[lengthArray];

                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }

                    tempArray[lengthArray - 1] = number;
                    array = tempArray;
                }
                else if (message == messageSum)
                {
                    int arraySum = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }

                    Console.WriteLine($"Сумма массива: {arraySum} ");
                }
            }
            Console.Clear();
            Console.WriteLine("Конец программы!");
        }
    }
}
