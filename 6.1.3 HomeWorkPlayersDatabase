using System;
using System.Collections.Generic;

namespace HWPlayersDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            database.ShowMenu();

        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private int _lastID;

        public Database()
        {
            _lastID = 0;
        }

        public void ShowMenu()
        {
            bool isWork = true;

            while (isWork)
            {
                const string CommandAdd = "1";
                const string CommandBan = "2";
                const string CommandUnban = "3";
                const string CommandDelete = "4";
                const string CommandOutput = "5";
                const string CommandExit = "0";


                Console.WriteLine($"Выберите действие:" +
                    $"\n{CommandAdd}. Добавить игрока " +
                    $"\n{CommandBan}. Забанить игрока " +
                    $"\n{CommandUnban}. Разбанить игрока " +
                    $"\n{CommandDelete}. Удалить игрока " +
                    $"\n{CommandOutput}. Вывести всю нформацию об игроках " +
                    $"\n{CommandExit}. Выход\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAdd:
                        AddPlayer();
                        break;

                    case CommandBan:
                        BanPlayer();
                        break;

                    case CommandUnban:
                        UnbanPlayer();
                        break;

                    case CommandDelete:
                        DeletePlayer();
                        break;

                    case CommandOutput:
                        ShowInfoPlayers();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такой команды нет.");
                        break;
                }
            }
        }

        public void AddPlayer()
        {
            Console.Clear();
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите уровень: ");
            int level = ReadIntNumber();

            Player player = new Player(_lastID, name, level);
            _players.Add(player);
            _lastID++;
            Console.Clear();
        }

        public void BanPlayer()
        {
            Console.Clear();

            if (CheckBaseLength())
            {
                Console.WriteLine("Введите номер игрока которого хотите забанить: ");

                if (TryGetPlayer(out Player player) == false)
                {
                    player.Ban();
                }                
            }
        }

        public void UnbanPlayer()
        {
            Console.Clear();

            if (CheckBaseLength())
            {
                Console.WriteLine("Введите номер игрока которого хотите разбанить: ");

                if (TryGetPlayer(out Player player) == false)
                {
                    player.Unban();
                }
            }
        }

        public void DeletePlayer()
        {
            Console.Clear();

            if (CheckBaseLength())
            {
                Console.WriteLine("Введите номер игрока которого хотите удалить: ");

                if (TryGetPlayer(out Player player) == false)
                {
                    _players.Remove(player);
                    Console.Write("Игрок удален!");
                }
            }
        }

        public void ShowInfoPlayers()
        {
            Console.Clear();

            if (CheckBaseLength())
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                }
            }
        }

        private bool CheckBaseLength()
        {
            bool isCheck = true;

            if (_players.Count == 0)
            {
                Console.WriteLine("База пуста.");
                isCheck = false;
            }

            return isCheck;
        }

        private int ReadIntNumber()
        {
            string userInput = Console.ReadLine();
            int numberInput = 0;

            while ((int.TryParse(userInput, out numberInput) == false))
            {
                Console.WriteLine("Ошибка ввода! Проверьте введенные данные");

                userInput = Console.ReadLine();
            }

            return numberInput;
        }

        private bool TryGetPlayer(out Player playerFound)
        {
            bool isCheck = true;
            playerFound = null;

            while (isCheck)
            {
                int numberId = ReadIntNumber();

                foreach (var player in _players)
                {
                    if (player.IdNumber == numberId)
                    {
                        playerFound = player;
                        isCheck = false;
                    }
                }

                if (playerFound == null)
                {
                    Console.WriteLine("Ошибка! Игрок не найден, введите номер игрока из списка: ");
                }
            }

            return isCheck;
        }

        class Player
        {
            private string _name;
            private int _level;
            private bool _isBanned;

            public int IdNumber { get; private set; }

            public Player(int number, string name, int level, bool _isBanned = false)
            {
                IdNumber = number;
                _name = name;
                _level = level;
            }

            public void Ban()
            {
                if (_isBanned == true)
                {
                    Console.WriteLine("Действие не успешно. Игрок уже был забанен.");
                }
                else
                {
                    _isBanned = true;
                    ShowInfo();
                }
            }

            public void Unban()
            {
                if (_isBanned == false)
                {
                    Console.WriteLine("Действие не успешно. Игрок уже был разбанен.");
                }
                else
                {
                    _isBanned = false;
                    ShowInfo();
                }
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Уникальный номер - {IdNumber}\nНикнейм - {_name}\nУровень - {_level}");

                if (_isBanned == true)
                {
                    Console.WriteLine("Игрок забанен: да\n");
                }
                else if (_isBanned == false)
                {
                    Console.WriteLine("Игрок забанен: нет\n");
                }
            }
        }
    }
}
