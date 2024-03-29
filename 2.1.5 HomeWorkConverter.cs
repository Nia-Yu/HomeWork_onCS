using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float rubMoney;
            float cadMoney;
            float usdMoney;
            float currencyCount;
            string userInput;
            float rubToUsd = 0.0137f;
            float rubToCad = 0.0175f;
            float usdToRub = 73.18f;
            float usdToCad = 1.28f;
            float cadToRub = 57.06f;
            float cadToUsd = 0.779f;
            bool exitСommand = false;

            Console.WriteLine("Добро пожаловать в обменник валют. Доступны 3 валюты к обмену.");
            
            Console.WriteLine("Введите сколько у вас рублей на счету: ");
            rubMoney = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите сколько у вас долларов на счету: ");
            usdMoney = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Введите сколько у вас канадских долларов на счету: ");
            cadMoney = Convert.ToSingle(Console.ReadLine());            

            while (exitСommand == false)
            {
                Console.WriteLine("Выберите вариант обмена:\n" +
                    "1 - рубли → доллары \n" +
                    "2 - доллары → рубли \n" +
                    "3 - рубли → канадские доллары \n" +
                    "4 - канадские доллары → рубли \n" +
                    "5 - доллары → канадские доллары \n" +
                    "6 - канадские доллары → доллары \n" +
                    "0 - выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Write("Обмен рублей на доллары. \n" +
                            "Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rubMoney >= currencyCount)
                        {
                            rubMoney -= currencyCount;
                            usdMoney += currencyCount * rubToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Конвертируемая сумма превышает ваш баланс.");
                        }
                        break;
                    case "2":
                        Console.Write("Обмен доллары на рубли. \n" +
                            "Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usdMoney >= currencyCount)
                        {
                            usdMoney -= currencyCount;
                            rubMoney += currencyCount * usdToRub;
                        }
                        else
                        {
                            Console.WriteLine("Конвертируемая сумма превышает ваш баланс.");
                        }
                        break;
                    case "3":
                        Console.Write("Обмен рублей на канадские доллары. \n" +
                            "Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rubMoney >= currencyCount)
                        {
                            rubMoney -= currencyCount;
                            cadMoney += currencyCount * rubToCad;
                        }
                        else
                        {
                            Console.WriteLine("Конвертируемая сумма превышает ваш баланс.");
                        }
                        break;
                    case "4":
                        Console.Write("Обмен канадские доллары на рубли. \n" +
                            "Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (cadMoney >= currencyCount)
                        {
                            cadMoney -= currencyCount;
                            rubMoney += currencyCount * cadToRub;
                        }
                        else
                        {
                            Console.WriteLine("Конвертируемая сумма превышает ваш баланс.");
                        }
                        break;
                    case "5":
                        Console.Write("Обмен доллары на канадские доллары. \n" +
                            "Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usdMoney >= currencyCount)
                        {
                            usdMoney -= currencyCount;
                            cadMoney += currencyCount * usdToCad;
                        }
                        else
                        {
                            Console.WriteLine("Конвертируемая сумма превышает ваш баланс.");
                        }
                        break;
                    case "6":
                        Console.Write("Обмен канадские доллары на доллары. \n" +
                            "Сколько вы хотите обменять: ");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (cadMoney >= currencyCount)
                        {
                            cadMoney -= currencyCount;
                            usdMoney += currencyCount * cadToUsd;
                        }
                        else
                        {
                            Console.WriteLine("Конвертируемая сумма превышает ваш баланс.");
                        }
                        break;
                    case "0":
                        exitСommand = true;
                        break;
                }

                Console.WriteLine($"Ваш баланс {rubMoney} rub,\n" +
                    $"{usdMoney} usd,\n" +
                    $"{cadMoney} cad.");
            }
        }
    }
}
