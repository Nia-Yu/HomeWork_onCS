using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMPersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] surnames = new string[0];
            string[] posts = new string[0];
            bool isWork = true;

            while (isWork)
            {
                const string CommandAdd = "1";
                const string CommandOutput = "2";
                const string CommandDelete = "3";
                const string CommandSearch = "4";
                const string CommandExit = "0";
                
                Console.WriteLine($"\n{CommandAdd}. Добавить досье \n{CommandOutput}. Вывести все досье \n{CommandDelete}. Удалить досье \n{CommandSearch}. Поиск по фамилии \n{CommandExit}. Выход\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAdd:
                        CreateDossier(ref surnames, ref posts);
                        break;

                    case CommandOutput:
                        OutputInfoDossier(surnames, posts);
                        break;

                    case CommandDelete:
                        DeleteDossier(ref surnames, ref posts);
                        break;

                    case CommandSearch:
                        SearchDossier(surnames, posts);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }
            }
        }

        static void CreateDossier(ref string[] surnames, ref string[] posts)
        {
            Console.WriteLine("\nВведите фамилию: \n");
            string surname = Console.ReadLine();
            ExpandArray(surname, ref surnames);
            Console.WriteLine("\nВведите должность: \n");
            string post = Console.ReadLine();
            ExpandArray(post, ref posts);

            Console.WriteLine("\nДанные добавлены!");
        }

        static void DeleteDossier(ref string[] firstArray, ref string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                Console.WriteLine("\nВведите номер досье для удаления: \n");
                int numberDelete = int.Parse(Console.ReadLine());
                
                if (numberDelete <= firstArray.Length)
                {
                    ReduceArray(numberDelete, ref firstArray);
                    ReduceArray(numberDelete, ref secondArray);
                    Console.WriteLine("\nДанные удалены!");
                }
                else
                {
                    Console.WriteLine("\nТакого досье не существует.");
                }
            }
            else
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }

        static void ExpandArray(string word, ref string[] array)
        {
            string[] temp = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            temp[temp.Length - 1] = word;
            array = temp;
        }

        static void OutputInfoDossier(string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {firstArray[i]}-{secondArray[i]}");
                }
            }
            else
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }

        static void ReduceArray(int numberDelete, ref string[] array)
        {
            if (array.Length != 0)
            {
                string[] temp = new string[array.Length - 1];
                int position = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (i != (numberDelete - 1))
                    {
                        temp[position] = array[i];
                        position++;
                    }
                }

                array = temp;
            }
            else
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }

        static void SearchDossier(string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                Console.WriteLine("\nВведите фамилию: \n");
                string surnameSearch = Console.ReadLine();
                bool isFound = false;

                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] == surnameSearch)
                    {
                        if (isFound == false)
                        {
                            Console.WriteLine("\nНайдено следующее: \n");
                            isFound = true;
                        }
                        Console.WriteLine($"{i + 1}. {firstArray[i]}-{secondArray[i]}");
                    }
                }
                
                if (isFound == false)
                {
                    Console.WriteLine("\nФамилия не найдена\n");
                }
            }
            else
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }
    }
}
