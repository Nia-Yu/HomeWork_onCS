using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPolyclinic
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount;
            int appointmentTime = 10;
            int waitingHours;
            int waitingMinutes;

            Console.Write("Вас привествует поликлиника №1. Сколько человек вы видете перед собой в очереди? ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            waitingHours = peopleCount * appointmentTime / 60;
            waitingMinutes = peopleCount * appointmentTime % 60;
            peopleCount++;

            Console.WriteLine("Ваш талон № " + peopleCount + ". Время ожидания в очереди " + waitingHours + 
                " часа, " + waitingMinutes + " минут.");
        }
    }
}
