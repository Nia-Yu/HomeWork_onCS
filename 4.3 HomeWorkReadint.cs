using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWReadint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReadInt());
        }

        static int ReadInt()
        {
            string number;
            int convertNumber = 0;
            bool isNumber = false;

            while (isNumber == false)
            {
                Console.Write("Введите число: ");
                number = Console.ReadLine();
                isNumber = int.TryParse(number, out convertNumber);

                if (isNumber == false)
                {
                    Console.WriteLine("Не удалось преобразовать.");
                }
            }

            return convertNumber;
        }
    }
}
