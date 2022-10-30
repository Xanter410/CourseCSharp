using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input;
            int length;
            int minNum = int.MaxValue;

            Console.WriteLine("Поиск наименьшего элемента в последовательности!");
            Console.Write("Введите длину последовательности: ");
            length = int.Parse(Console.ReadLine());

            Console.WriteLine("Последовательно вводите числа, разделяя их клавишей Enter:");
            for (int i = 0; i < length; i++)
            {
                input = int.Parse(Console.ReadLine());

                if (input < minNum)
                {
                    minNum = input;
                }
            }

            Console.WriteLine($"Наименьшее число из последовательности равно: {minNum}");
            Console.ReadKey();
        }
    }
}
