using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework_5
{
    internal class Program
    {
        static string filePath = "Сотрудники.txt";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\t Меню");
                Console.WriteLine("1 - Вывести данные на экран.");
                Console.WriteLine("2 - Добавить новую запись.");
                Console.WriteLine("3 - Выйти.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        var info = readInfoEmployee(filePath);
                        consoleWriteInfoEmployee(info);
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("\n Добавление новой записи:");
                        var addinfo = addEntry();
                        addEntryToFile(filePath, addinfo);
                        break;

                    case ConsoleKey.Escape:
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Чтение параметров всех сотрудников из файла.
        /// </summary>
        /// <returns>Массив из данных по 7 элементов на каждого сотрудника.</returns>
        static private string[] readInfoEmployee(string fileName)
        {
            if (File.Exists(fileName))
            {
                List<string> result = new List<string>();
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        foreach (var item in sr.ReadLine().Split('#'))
                        {
                            result.Add(item);
                        }
                    }
                }
                return result.ToArray();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Форматированный вывод информации о всех сотрудниках.
        /// </summary>
        static private void consoleWriteInfoEmployee(string[] InfoEmployee)
        {
            int index = -1;
            Console.WriteLine();

            foreach (var item in InfoEmployee)
            {
                if (index >= 6)
                {
                    index = 0;
                    Console.WriteLine();
                }
                else
                {
                    index++;
                }

                Console.WriteLine(infoEmployeeOfIndex(index) + item);
            }
        }

        /// <summary>
        /// Описание отдельно взятых параметров для форматированного вывода
        /// </summary>
        /// <returns>Описание параметра по индексу от 0 до 6</returns>
        static private string infoEmployeeOfIndex(int index)
        {
            string Result = null;

            switch (index)
            {
                case 0:
                    Result = "ID: ";
                    break;
                case 1:
                    Result = "Дата добавления: ";
                    break;
                case 2:
                    Result = "Полное имя: ";
                    break;
                case 3:
                    Result = "Возраст: ";
                    break;
                case 4:
                    Result = "Рост: ";
                    break;
                case 5:
                    Result = "Дата рождения: ";
                    break;
                case 6:
                    Result = "Место рождения: ";
                    break;
                default:
                    break;

            }
            return Result;
        }

        /// <summary>
        /// Считывание информации о сотруднике от пользователя.
        /// </summary>
        /// <returns>Массив параметров</returns>
        static private string[] addEntry()
        {
            int index = -1;
            string[] result = new string[7];
            for (int i = 0; i < 7; i++)
            {
                index = index >= 6 ? 0 : index + 1;
                Console.Write($"Введите {infoEmployeeOfIndex(index)}");
                result[index] = Console.ReadLine();
            }
            return result;
        }

        /// <summary>
        /// Добавление записи о сотруднике в файл.
        /// </summary>
        static private void addEntryToFile(string fileName, string[] infoEmployee)
        {
            using (StreamWriter sr = new StreamWriter(fileName, true, Encoding.UTF8))
            {
                string temp = null;
                for (int i = 0; i < 6; i++)
                {
                    temp = temp + infoEmployee[i] + "#";
                }
                temp = temp + infoEmployee[6];

                sr.WriteLine(temp);
            }
        }
    }
}
