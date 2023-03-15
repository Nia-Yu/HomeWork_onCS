using System;

namespace HWSplitMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;

            Console.WriteLine("Введите текст:");
            text = Console.ReadLine();

            string[] linesArray = text.Split(' ');

            foreach (var line in linesArray)
            {
                Console.WriteLine(line);
            }
        }
    }
}
