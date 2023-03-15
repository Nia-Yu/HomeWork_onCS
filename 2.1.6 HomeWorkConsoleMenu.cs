using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string setName = "";
            string passwordInput;
            string setPassword = null;
            string commandInput;
            string userInput;
            bool clickExit = false;
            Random random = new Random();
            int minRandomValue = 0;
            int maxRandomValue = 100;

            while (clickExit == false)
            {
                Console.WriteLine("\nСписок команд:\n" +
                   "SetName  - установить имя \n" +
                   "SetPassword – установить пароль \n" +
                   "WriteName – вывести имя (после ввода пароля) \n" +
                   "ChangeConsoleColor - изменить цвет консоли \n" +
                   "ChangeTextColor - изменить цвет текст \n" +
                   "WriteRandomNumber - вывести рандомное число \n" +
                   "Esc – выход");
                Console.WriteLine("Введите команду: ");
                commandInput = Console.ReadLine();

                if (commandInput == "SetName")
                {
                    Console.WriteLine("Введите имя: ");
                    setName = Console.ReadLine();
                    Console.Clear();
                }
                else if (commandInput == "SetPassword")
                {
                    Console.WriteLine("Установите пароль: ");
                    setPassword = Console.ReadLine();
                    Console.Clear();
                }
                else if (commandInput == "WriteName")
                {
                    if (setPassword != null)
                    {
                        Console.WriteLine("Введите пароль: ");
                        passwordInput = Console.ReadLine();
                        if (passwordInput == setPassword)
                        {
                            Console.Clear();
                            Console.WriteLine(setName);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Пароль не верный!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Пароль не установлен! Введите команду для установки пароля.");
                    }
                }
                else if (commandInput == "ChangeConsoleColor")
                {
                    Console.WriteLine("Выбирете цвет:\n" +
                   "1  - синий \n" +
                   "2 – красный \n" +
                   "3 – зеленый \n" +
                   "4 - розовый \n" +
                   "5 - желтый \n" +
                   "6 - белый \n" +
                   "7 – черный");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;

                        case "2":
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;

                        case "3":
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;

                        case "4":
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            break;

                        case "5":
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;

                        case "6":
                            Console.BackgroundColor = ConsoleColor.White;
                            break;

                        case "7":
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                    Console.Clear();
                }
                else if (commandInput == "ChangeTextColor")
                {
                    Console.WriteLine("Выбирете цвет:\n" +
                     "1  - синий \n" +
                     "2 – красный \n" +
                     "3 – зеленый \n" +
                     "4 - розовый \n" +
                     "5 - желтый \n" +
                     "6 - белый \n" +
                     "7 – черный");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        case "2":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        case "3":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case "4":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;

                        case "5":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;

                        case "6":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case "7":
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                    }
                    Console.Clear();
                }
                else if (commandInput == "WriteRandomNumber")
                {
                    int i = random.Next(minRandomValue, maxRandomValue);
                    Console.Clear();
                    Console.WriteLine(i);
                }
                else if (commandInput == "Esc")
                {
                    Console.Clear();
                    clickExit = true;
                    Console.WriteLine("Конец программы!");
                }
            }
        }
    }
}
