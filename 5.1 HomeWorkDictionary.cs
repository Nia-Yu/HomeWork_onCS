using System;
using System.Collections.Generic;
using System.IO;

namespace HMDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> translator = new Dictionary<string, string>();
            string userInput = "";

            translator.Add("dog", "Собака");
            translator.Add("cat", "кошка");
            translator.Add("duck", "утка");
            translator.Add("love", "любовь");
            translator.Add("forever", "навесегда");
            translator.Add("point", "точка");
            translator.Add("save", "сохранить");
            translator.Add("queen", "королева");
            translator.Add("exercising", "упражняться");
            translator.Add("follow", "следовать");

            Console.WriteLine("Все английские слова в словаре:");

            foreach(var word in translator.Keys)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\nВведите слово значение которого вы хотите узнать:");
            userInput = Console.ReadLine();

            if (translator.ContainsKey(userInput))
            {
                Console.WriteLine($"\nСлово {userInput} - значение {translator[userInput]}");
            }
            else
            {
                Console.WriteLine("Такого слова в словаре нет!");
            }
        }
    }
}
