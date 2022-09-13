using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWUielement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxValueBar = 10;
            int minValuePercentage = 0;
            int maxValuePercentage = 100;

            Console.Write("Введите символ для хелфбара: ");
            char symbolHealth = Convert.ToChar(Console.ReadLine());

            Console.Write($"Введите процент текущего здоровья (от {minValuePercentage} до {maxValuePercentage}): ");
            int health = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите символ для манабара: ");
            char symbolMana = Convert.ToChar(Console.ReadLine());

            Console.Write($"Введите процент текущей маны (от {minValuePercentage} до {maxValuePercentage}): ");
            int mana = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            DrawBar(health, maxValueBar, 0, symbolMana, minValuePercentage, maxValuePercentage) ;
            DrawBar(mana, maxValueBar, 1, symbolMana, minValuePercentage, maxValuePercentage);
        }

        static void DrawBar(int value, int maxValueBar, int positionX, char symbol, int minValuePercentage, int maxValuePercentage)
        {
            if (value >= minValuePercentage && value <= maxValuePercentage)
            {
                int currentValue = (maxValueBar * value) / maxValuePercentage;
                string bar = "";
                Console.SetCursorPosition(0, positionX);
                Console.Write('[');

                for (int i = 0; i < currentValue; i++)
                {
                    bar += symbol;
                }

                Console.Write(bar);
                bar = "";

                for (int i = currentValue; i < maxValueBar; i++)
                {
                    bar += ' ';
                }

                Console.Write(bar + ']');
            }
            else
            {
                Console.WriteLine("Введено отрицательное или превышающее предел значение");
            }
        }
    }
}
