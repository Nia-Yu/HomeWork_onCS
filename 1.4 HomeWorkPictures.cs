using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int countInRow = 3;
            int allPictures = 52;
            int countRows;
            int restOfPictures;

            countRows = allPictures / countInRow;
            restOfPictures = allPictures % countInRow;

            Console.WriteLine($"Количество полностью заполненых рядов: {countRows} " +
                $"и количество картинок сверх меры: {restOfPictures}.");
        }
    }
}
