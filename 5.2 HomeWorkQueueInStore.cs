using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace HMQueueInStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> receipts = new Queue<int>();
            int sumInBoxOffice = 0;
            int sumReceipt;

            FillUpQueue(receipts);

            while(receipts.Count != 0)
            {
                Console.WriteLine("Очередь в магазине:");
                sumReceipt = MakeReceipt(receipts);
                sumInBoxOffice += sumReceipt;
                Console.WriteLine($"Сумма в кассе: {sumInBoxOffice}");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Все чеки обслужены. Сумма в кассе {sumInBoxOffice}");
        }

        static void FillUpQueue(Queue<int> receipts)
        {
            int peopleInLine = 5;
            Random random = new Random();
            int minMeaningRamdom = 1;
            int maxMeaningRamdom = 200;

            for (int i = 0; i < peopleInLine; i++)
            {
                receipts.Enqueue(random.Next(minMeaningRamdom, maxMeaningRamdom));
            }
        }

        static int MakeReceipt(Queue<int> receipts)
        {
            int nextReceipt;

            foreach (int receipt in receipts)
            {
                Console.WriteLine(receipt);
            }

            nextReceipt = receipts.Dequeue();
            Console.WriteLine($"\nСледующий чек - {nextReceipt}");

            return nextReceipt;
        }
    }
}
