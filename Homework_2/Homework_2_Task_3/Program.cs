using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int count;
            bool isSimple;

            Console.Write("Введите число, а мы проверим простое оно или нет: ");

            num = int.Parse(Console.ReadLine());

            count = 2;
            isSimple = true;
            while (count <= num - 1)
            {
                if (num % count == 0)
                {
                    isSimple = false;
                    break;
                }
                count++;
            }

            if (isSimple)
            {
                Console.Write("Число простое!");
            }
            else
            {
                Console.Write("Это число не простое...");
            }

            Console.ReadKey();
        }
    }
}
