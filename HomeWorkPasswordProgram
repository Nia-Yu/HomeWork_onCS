using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPasswordProgram 
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "123qwerty";
            string secretMessage = "Цой жив!";
            string userInput;
            int tryCount = 3;

            for (int i = 1; i <= tryCount; i++)
            {
                Console.WriteLine("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine(secretMessage);
                    break;
                }
                else
                {
                    Console.Write("Осталось попыток " + (tryCount - i) + ". ");
                    if ((tryCount - i) > 0)
                    {
                        Console.WriteLine("Попробуйте еще раз!");
                    }
                    else
                    {
                        Console.WriteLine("Вход заблокирован!");
                    }
                }
            }
        }
    }
}
