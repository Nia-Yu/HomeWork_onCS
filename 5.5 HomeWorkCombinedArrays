using System;
using System.Collections.Generic;

namespace HMCombinedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "1", "2", "4", "1", "2", "3" };
            string[] arraySecond = { "3", "5", "7", "1", "6" };
            List<string> line = new List<string>();

            MergeArrays(line, array);
            MergeArrays(line, arraySecond);

            Console.WriteLine();

            for (int i = 0; i < line.Count; i++)
            {
                Console.WriteLine(line[i]);
            }
        }

        static void MergeArrays(List<string> line, string[] array)
        {
            foreach(string item in array)
            {
                if (line.Contains(item) == false)
                {
                    line.Add(item);
                }

                Console.Write(item);
            }
        }
    }
}
