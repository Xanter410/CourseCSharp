using System;
using System.Collections.Generic;

namespace Homework_7_Task_3
{
    internal class Program
    {
        static private HashSet<int> _list = new HashSet<int>();
        static void Main(string[] args)
        {
            ShowMenu();

            ShowHashSet();

            Console.ReadLine();
        }

        static private void ShowMenu()
        {
            string input;
            int num;

            Console.WriteLine("Если хотите закончить ввод чител, просто отправьте пустую строку.");
            while (true)
            {
                Console.Write("Введите любое число:");
                input = Console.ReadLine();
                if (input == "")
                    break;

                num = int.Parse(input);

                if (!_list.Contains(num))
                {
                    _list.Add(num);
                    Console.WriteLine("Число успешно сохранено!");
                }
                else
                {
                    Console.WriteLine("Такое число уже было введено ранее :(");
                }
            }
        }

        static private void ShowHashSet()
        {
            Console.WriteLine("Сохраненные данные:");
            int index = 0;
            foreach (var item in _list)
            {
                index++;
                Console.Write($"{item, 5} ");
                if (index >= 5)
                {
                    Console.WriteLine();
                    index = 0;
                } 
            }
        }
    }
}
