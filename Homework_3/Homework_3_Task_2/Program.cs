using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод на экран двух матриц заданного размера заполненных случайными числами и третьей матрицы являющийся их суммой.");
            Console.Write("Введите количество строк матрицы: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов матрицы: ");
            int m = int.Parse(Console.ReadLine());

            int[,] arrayA = new int[n, m];
            int[,] arrayB = new int[n, m];
            int[,] arrayC = new int[n, m];

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arrayA[i, j] = random.Next(50);

                    arrayB[i, j] = random.Next(50);

                    arrayC[i, j] = arrayA[i, j] + arrayB[i, j];
                }
            }

            Console.WriteLine(" Массив А:");
            printArray2D(arrayA);
            Console.WriteLine("\n Массив B:");
            printArray2D(arrayB);
            Console.WriteLine("\n Массив C (сумма А и B):");
            printArray2D(arrayC);

            Console.ReadKey();
        }

        static private void printArray2D(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j],3} ");
                }
                Console.WriteLine();
            }
        } 
    }
}
