using System;

namespace Homework_2_Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            int num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("Данное число и правда четное!");
            }
            else
            {
                Console.WriteLine("К сожалению, число не четное :(");
            }

            Console.ReadKey();
        }
    }
}
