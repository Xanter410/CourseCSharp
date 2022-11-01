using System;
using System.Collections.Generic;

namespace Homework_7_Task_1
{
    internal class Program
    {
        static private void Main(string[] args)
        {
            List<int> ints = new List<int>();

            FillList(ints);
            ShowList(ints);

            Console.ReadKey();

            DelElemList(ints);
            ShowList(ints);

            Console.ReadKey();
        }

        static private void FillList(List<int> ints)
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                ints.Add(random.Next(0, 101));
            }
        }

        static private void DelElemList(List<int> ints)
        {
            ints.RemoveAll(i => i > 25 && i < 50);
        }

        static private void ShowList(List<int> ints)
        {
            int index = 0;
            Console.WriteLine();

            foreach (var item in ints)
            {
                index++;
                Console.Write($"{item,4} ");
                if (index >= 20)
                {
                    Console.WriteLine();
                    index = 0;
                }
            }
        }
    }
}
