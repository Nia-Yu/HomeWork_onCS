using System;
using System.IO;

namespace HWWorkingWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Nia", 25, "ya@ya.ru", Country.Canada, 1);

            player.ShowInfo();  
        }
    }

    enum Country
    {
        Russia,
        USA,
        Canada
    }

    class Player
    {
        private string _name;
        private int _age;
        private string _mail;
        private Country _country;
        private int _level;

        public Player(string name, int age, string mail, Country country, int level)
        {
            _name = name;
            _age = age;
            _mail = mail;
            _country = country;
            _level = level;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {_name}\nВозраст - {_age}\nПочта - {_mail}\nСтрана - {_country}\nУровень - {_level}");
        }
    }
}
