using System;
using System.IO;

namespace HWWorkingWithProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Rendering rendering = new Rendering();
            Player player = new Player(10,6);

            rendering.DrawPlayer(player.PositionX, player.PositionY);
        }
    }

    class Rendering
    {
        public void DrawPlayer(int x, int y, char symbol = '@')
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(symbol);
        }
    }

    class Player
    {
        private int _positionX;

        public int PositionX
        {
            get
            {
                return _positionX;
            }
            private set
            {
                _positionX = value;
            }
        }
        public int PositionY { get; private set; }

        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
