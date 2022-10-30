using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод на экран матрицы заданного размера заполненную случайными числами.");
            Console.Write("Введите количество строк матрицы: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы: ");
            int m = int.Parse(Console.ReadLine());

            int[,] array = new int[n, m];
            
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = random.Next(100);
                    Console.Write($"{array[i, j],2} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
