using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string stringSymbols = "";
            char userCharacter;
            int nameLengthWithSymbols;

            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();

            Console.WriteLine("Введите символ:");
            userCharacter = Convert.ToChar(Console.ReadLine());

            nameLengthWithSymbols = name.Length + 2;

            for (int i = 0; i < nameLengthWithSymbols; i++)
            {
                stringSymbols += userCharacter;
            }

            Console.WriteLine(stringSymbols + "\n" + userCharacter + name + userCharacter + "\n" + stringSymbols);

        }
    }
}
