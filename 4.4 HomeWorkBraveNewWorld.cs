using System;
using System.IO;
using System.Threading;

namespace HMBraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int sumHeart = 0;
            bool isPlaying = true;
            char symbolHeart = '♥';
            char[,] map =
             {
                {'#',' ','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ','#','♥','#','#',' ','#',' ','#','#','♥',' ','#','#' },
                {'#',' ',' ',' ',' ',' ','#',' ',' ',' ','#','#',' ','♥','#' },
                {'#','#',' ','#','#',' ','#',' ','#',' ',' ',' ',' ','#','#' },
                {'#',' ',' ','♥','#',' ',' ',' ','#',' ','♥','#',' ',' ','#' },
                {'#','#',' ',' ','#','♥','#','♥',' ','#','#','#',' ',' ','#' },
                {'#',' ',' ','#',' ','#',' ',' ',' ',' ',' ','#',' ','#','#' },
                {'#','♥','#',' ','#','♥',' ','#','♥','#',' ',' ',' ',' ','#' },
                {'#',' ',' ','#','♥','#',' ','♥','#',' ','♥','#','#',' ','#' },
                {'#','#',' ',' ',' ',' ',' ','#',' ',' ','#','#','#','♥','#' },
                {'#',' ','#','#',' ','♥','#',' ',' ',' ',' ',' ',' ','#','#' },
                {'#','♥',' ',' ',' ','#','#',' ','#',' ','♥','#',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','_','#' },
            };
            int userPositionX = 1;
            int userPositionY = 0;

            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(0, 15);
                Console.WriteLine($"Пройди лабиринт! Собери как можно больше {symbolHeart}");
                Console.SetCursorPosition(0, 0);

                DrawPlayer(userPositionX, userPositionY);

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                Console.SetCursorPosition(userPositionX, userPositionY);
                Console.Write(' ');

                MovePlayer(pressedKey, map, ref userPositionY, ref userPositionX);

                char symbolEndGame = '_';

                if (map[userPositionY, userPositionX] == symbolHeart)
                {
                    map[userPositionY, userPositionX] = ' ';

                    sumHeart += 1;
                }
                else if (map[userPositionY, userPositionX] == symbolEndGame)
                {
                    Console.Clear();
                    Console.WriteLine($"Лабирин пройден!!! Собрано {sumHeart} {symbolHeart}");
                    isPlaying = false;
                }
            }
        }

        static void MovePlayer(ConsoleKeyInfo pressedKey, char[,] map, ref int positionX, ref int positionY)
        {
            int[] direction = GetDirection(pressedKey);

            int nextUserPositionX = positionX + direction[0];
            int nextUserPositionY = positionY + direction[1];
            char nextSymbol = map[nextUserPositionX, nextUserPositionY];

            if (nextSymbol != '#')
            {
                positionX = nextUserPositionX;
                positionY = nextUserPositionY;
            }
        }

        static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };
            const ConsoleKey UpDirection = ConsoleKey.UpArrow;
            const ConsoleKey DownDirection = ConsoleKey.DownArrow;
            const ConsoleKey LeftDirection = ConsoleKey.LeftArrow;
            const ConsoleKey RightDirection = ConsoleKey.RightArrow;

            switch (pressedKey.Key)
            {
                case UpDirection:
                    direction[0] = -1;
                    break;

                case DownDirection:
                    direction[0] = 1;
                    break;

                case LeftDirection:
                    direction[1] = -1;
                    break;

                case RightDirection:
                    direction[1] = 1;
                    break;

                default:
                    Console.CursorVisible = true;
                    break;
            }

            return direction;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void DrawPlayer(int userPositionX, int userPositionY)
        {
            string user = "☻";
            Console.SetCursorPosition(userPositionX, userPositionY);
            Console.Write(user);
        }
    }
}
