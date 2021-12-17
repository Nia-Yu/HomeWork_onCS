using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWStore
{
    class Program
    {
        static void Main(string[] args)
        {
            int money;
            int cristalsCount;
            int cristalPrice = 2;

            Console.WriteLine("Добро пожаловать! Сколько у вас золота? ");
            money = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Один кристал стоит {cristalsPrice} монеты. Cколько кристалов вы хотите приобрести?");
            cristalsCount = Convert.ToInt32(Console.ReadLine());

            money -= cristalsPrice * cristalsCount;
            Console.WriteLine($"Теперь у вас есть {cristalsCount} и {money}.");
        }
    }
}
