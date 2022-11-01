using System;
using System.Globalization;
using System.Linq;

namespace Homework_6_Task_1
{
    internal class Program
    {
        static private string _filePath = @"Сотрудники.txt";
        static private Repository _repository = null;
        static private Worker[] _lastWorkers = null;

        static void Main(string[] args)
        {
            _repository = new Repository(_filePath);

            showMenu();
        }

        /// <summary>
        /// Главное меню приложения
        /// </summary>
        static private void showMenu()
        {
            while (true)
            {
                
                Console.WriteLine("- - - - - - - Меню - - - - - - -");
                Console.WriteLine("1 - Вывести все записи на экран.");
                Console.WriteLine("2 - Вывести запись по ID.");
                Console.WriteLine("3 - Создание новой записи.");
                Console.WriteLine("4 - Удаление записи по ID.");
                Console.WriteLine("5 - Вывести записи в выбранном диапазоне дат.");
                Console.WriteLine("6 - Сортировать последний выведенный список.");
                Console.WriteLine("7 - Закрыть приложение.");
                Console.WriteLine("- - - - - - - - - - - - - - - -");
                Console.Write("Введите номер действия: ");


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        ShowAllWorkers();
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine();
                        ShowWorkerById();
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine();
                        CreateNewWorker();
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine();
                        DeleteWorker();
                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine();
                        ShowWorkersBetweenTwoDates();
                        break;

                    case ConsoleKey.D6:
                        Console.WriteLine();
                        SortWorkers();
                        break;

                    case ConsoleKey.Escape:
                    case ConsoleKey.D7:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Вывести всех работников
        /// </summary>
        static private void ShowAllWorkers()
        {
            Worker[] workers = _repository.GetAllWorkers();
            if (workers != null)
            {
                ShowWorkers(workers);
            }
            else
            {
                Console.WriteLine("Файл с данными не найден.");
            }
            
        }

        /// <summary>
        /// Поиск работников по ID. 
        /// Запрос ID выполняется автоматически.
        /// </summary>
        static private void ShowWorkerById()
        {
            Console.Write("Введите ID нужной записи: ");
            int id = int.Parse(Console.ReadLine());

            Worker worker = _repository.GetWorkerById(id);

            if (worker.Id != -1)
            {
                ShowWorkers(worker);
            }
            else
            {
                Console.WriteLine($"Запись с ID = {id}, не найдена.");
            }
        }

        /// <summary>
        /// Создание новой записи о работнике. 
        /// Запрос всех данных выполняется автоматически.
        /// </summary>
        static private void CreateNewWorker()
        {
            Console.WriteLine("Ввод данных о работнике");
            string[] data = DataRequest(2);

            _repository.AddWorker(
                new Worker(
                    data[0],
                    int.Parse(data[1]),
                    int.Parse(data[2]), 
                    DateTime.ParseExact(data[3],"dd.MM.yyyy",CultureInfo.InvariantCulture), 
                    data[4]));
            Console.WriteLine("Новая запись добавлена.");
        }

        /// <summary>
        /// Удаление записи работника по ID.
        /// Запрос ID выполняется автоматически.
        /// </summary>
        static private void DeleteWorker()
        {
            Console.Write("Введите ID нужной записи: ");
            int id = int.Parse(Console.ReadLine());

            Worker worker = _repository.GetWorkerById(id);

            if (worker.Id != -1)
            {
                _repository.DeleteWorker(worker.Id);
            }
            else
            {
                Console.WriteLine($"Запись с ID = {id}, не найдена.");
            }
        }

        /// <summary>
        /// Поиск записей в диапазоне двух дат.
        /// Запрос дат выполняется автоматически.
        /// </summary>
        static private void ShowWorkersBetweenTwoDates()
        {
            Console.Write("Введите ОТ какой даты нужно искать записи (например, 30.11.2022): ");
            DateTime dateFrom = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите ДО какой даты нужно искать записи: ");
            DateTime dateTo = DateTime.Parse(Console.ReadLine());

            Worker[] workers = _repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);

            if (workers != null)
            {
                if (workers.Length != 0)
                {
                    ShowWorkers(workers);
                }
                else
                {
                    Console.WriteLine("Не найдено ни одной записи.");
                }
            }
            else
            {
                Console.WriteLine("Файл с данными не найден.");
            }
        }

        /// <summary>
        /// Меню сортировки списка записей. 
        /// Требуется заранее вывести любой набор записей.
        /// </summary>
        static private void SortWorkers()
        {
            if (_lastWorkers != null)
            {
                Console.WriteLine("Выберете по какому параметру требуется сортировка:");
                Console.WriteLine("1 - По ID");
                Console.WriteLine("2 - По Дате создания");
                Console.WriteLine("3 - По Имени");
                Console.WriteLine("4 - По Возрасту");
                Console.WriteLine("5 - По Росту");
                Console.WriteLine("6 - По Дате рождения");
                Console.WriteLine("7 - По Месту проживания");


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.Id));
                        break;

                    case ConsoleKey.D2:
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.DateAndTimeOfCreation));
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine();
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.FullName));
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine();
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.Age));
                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine();
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.Height));
                        break;

                    case ConsoleKey.D6:
                        Console.WriteLine();
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.DateOfBirth));
                        break;

                    case ConsoleKey.D7:
                        Console.WriteLine();
                        ShowWorkers(_lastWorkers.OrderBy(Worker => Worker.PlaceOfBirth));
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Похоже вы еще не формировали списки работников.");
            }

            

        }

        /// <summary>
        /// Считывание информации о сотруднике от пользователя.
        /// </summary>
        /// <param name="param">
        /// 0 - считывание всех параметров.
        /// 1 - считывание без ID.
        /// 2 - считывание без ID и даты создания.
        /// </param>
        /// <returns>Массив параметров</returns>
        static private string[] DataRequest(int param)
        {
            int index = param;
            string[] result = new string[7];
            string[] titles = _repository.titles;

            for (int i = 0; i < 7 - param; i++)
            {
                Console.Write($"Введите {titles[index]}: ");
                result[i] = Console.ReadLine();
                index++;
            }
            return result;
        }

        /// <summary>
        /// Вывод заголовка таблицы.
        /// </summary>
        static private void WriteTitles()
        {
            string[] titles = _repository.titles;
            Console.WriteLine(
                $"{titles[0],3} " +
                $"{titles[1],25} " +
                $"{titles[2],35} " +
                $"{titles[3],10} " +
                $"{titles[4],7} " +
                $"{titles[5],15} " +
                $"{titles[6],20} ");
        }

        /// <summary>
        /// Вывод записей о работниках.
        /// </summary>
        /// <param name="workers">Массив</param>
        static private void ShowWorkers(Worker[] workers)
        {
            _lastWorkers = workers;

            WriteTitles();
            foreach (var item in workers)
            {
                Console.WriteLine(item.Print());
            }
        }

        /// <summary>
        /// Вывод отсортерованных записей о работниках.
        /// </summary>
        /// <param name="workers">Отсортированный массив (.OrderBy)</param>
        static private void ShowWorkers(IOrderedEnumerable<Worker> workers)
        {
            WriteTitles();
            foreach (var item in workers)
            {
                Console.WriteLine(item.Print());
            }
        }

        /// <summary>
        /// Вывод одной записи о работнике.
        /// </summary>
        static private void ShowWorkers(Worker worker)
        {
            WriteTitles();
            Console.WriteLine(worker.Print());

        }
    }
}
