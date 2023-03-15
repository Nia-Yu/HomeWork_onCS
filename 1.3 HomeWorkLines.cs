using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            string zodiac;
            string placeWork;
            string favotiteFood;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Кто вы по гороскопу: ");
            zodiac = Console.ReadLine();
            Console.Write("Где вы работаете: ");
            placeWork = Console.ReadLine();
            Console.Write("Какое ваше любимое блюдо: ");
            favotiteFood = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}. Вам {age} лет. Вы {zodiac} и работаете {placeWork}. " +
                $"Ваша любимая еда - {favotiteFood}.");
        }
    }
}
