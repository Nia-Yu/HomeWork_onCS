using System;
using System.Collections.Generic;

namespace HMPersonnelAccounting2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            bool isWork = true;

            while (isWork)
            {
                const string CommandAdd = "1";
                const string CommandOutput = "2";
                const string CommandDelete = "3";
                const string CommandExit = "0";

                Console.WriteLine($"{CommandAdd}. Добавить досье \n{CommandOutput}. Вывести все досье \n{CommandDelete}. Удалить досье \n{CommandExit}. Выход\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAdd:
                        CreateDossier(dossiers);
                        break;

                    case CommandOutput:
                        OutputInfoDossier(dossiers);
                        break;

                    case CommandDelete:
                        DeleteDossier(dossiers);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет.");
                        break;
                }
            }
        }

        static void CreateDossier(Dictionary<string, string> dossiers)
        {
            Console.WriteLine("\nВведите фамилию: \n");
            string surname = Console.ReadLine();
            Console.WriteLine("\nВведите должность: \n");
            string post = Console.ReadLine();

            if (dossiers.ContainsKey(surname))
            {
                Console.WriteLine($"\nДосье с такой фамилией существует!");
            }
            else
            {
                dossiers.Add(surname, post);
                Console.WriteLine("\nДанные добавлены!\n");
            }
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            if (dossiers.Count != 0)
            {
                Console.WriteLine("\nВведите фамилию для удаления досье: \n");
                string userInput = Console.ReadLine();

                if (dossiers.ContainsKey(userInput))
                {
                    dossiers.Remove(userInput);
                    Console.WriteLine($"\nДосье удалено!");
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

        static void OutputInfoDossier(Dictionary<string, string> dossiers)
        {
            if (dossiers.Count != 0)
            {
                foreach (var dossier in dossiers)
                {
                    Console.WriteLine($"{dossier.Key} - {dossier.Value}");
                }
            }
            else
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }
    }
}
