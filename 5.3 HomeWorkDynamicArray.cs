using System;
using System.Collections.Generic;

namespace HWDynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";
            List<int> numbers = new List<int>();
            string userInput = "";
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите число, {CommandExit} или {CommandSum}: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSum:
                        ShowSum(numbers);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        AddNumber(numbers, userInput);
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Конец программы!");
        }

        static void AddNumber(List<int> numbers, string userInput)
        {
            bool isNumber = int.TryParse(userInput, out int number);

            if (isNumber == true)
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("\nНекорректный ввод\n");
            }
        }

        static void ShowSum(List<int> numbers)
        {
            int arraySum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                arraySum += numbers[i];
            }

            Console.WriteLine($"Сумма массива: {arraySum} ");
        }
    }
}
