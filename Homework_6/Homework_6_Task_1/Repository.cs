using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_6_Task_1
{
    internal class Repository
    {
        private string filePath;

        public string[] titles { get; }

        public Repository(string filePath)
        {
            this.filePath = filePath;
            this.titles = new string[]
            {
                "ID",
                "Дата и время добавления",
                "Полное имя",
                "Возраст",
                "Рост",
                "Дата рождения",
                "Место рождения"
            };

        }

        /// <summary>
        /// Чтение из файла и возврат массива всех записей.
        /// </summary>
        /// <returns></returns>
        public Worker[] GetAllWorkers()
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            List<Worker> workers = new List<Worker>();
            using (StreamReader sr = new StreamReader(this.filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    workers.Add(
                        new Worker(int.Parse(args[0]), 
                        DateTime.Parse(args[1]), 
                        args[2], 
                        int.Parse(args[3]), 
                        int.Parse(args[4]), 
                        DateTime.Parse(args[5]), 
                        args[6]));
                }
            }
            return workers.ToArray();
        }

        /// <summary>
        /// Чтение из файла и возврат записи с нужным ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Worker GetWorkerById(int id)
        {
            if (!File.Exists(filePath))
            {
                return new Worker(-1, DateTime.Now, "No found", 0, 0, DateTime.Now, "~");
            }
            using (StreamReader sr = new StreamReader(this.filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    if (int.Parse(args[0]) == id)
                    {
                        return new Worker(
                            int.Parse(args[0]),
                            DateTime.Parse(args[1]),
                            args[2],
                            int.Parse(args[3]),
                            int.Parse(args[4]),
                            DateTime.Parse(args[5]),
                            args[6]);
                    }
                }
            }
            return new Worker(-1,DateTime.Now,"No found",0,0,DateTime.Now,"~");
        }

        /// <summary>
        /// Перезапись файла с удалением одной записи по ID.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorker(int id)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            string temp = string.Empty;
            using (StreamReader sr = new StreamReader(this.filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    if (int.Parse(args[0]) != id)
                    {
                        temp = temp + String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}\n",
                                        args[0],args[1],args[2],args[3],args[4],args[5],args[6]);
                    }
                }
            }
            File.WriteAllText(filePath, temp);
        }

        /// <summary>
        /// Добавление в файл новой записи.
        /// </summary>
        /// <param name="worker"></param>
        public void AddWorker(Worker worker)
        {
            int index = 0;
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(this.filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split('#');

                        index = int.Parse(args[0]);
                    }
                }
                index++;
            }
            string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}\n",
                                        index,
                                        worker.DateAndTimeOfCreation,
                                        worker.FullName,
                                        worker.Age,
                                        worker.Height,
                                        worker.DateOfBirth.ToShortDateString(),
                                        worker.PlaceOfBirth);

            File.AppendAllText(filePath, temp);
        }

        /// <summary>
        /// Чтение из файла и возврат записей в диапазоне дат. 
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            List<Worker> workers = new List<Worker>();

            using (StreamReader sr = new StreamReader(this.filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');

                    DateTime create = DateTime.Parse(args[1]);

                    if (dateFrom <= create && create <= dateTo)
                    {
                        workers.Add(
                        new Worker(int.Parse(args[0]),
                        DateTime.Parse(args[1]),
                        args[2],
                        int.Parse(args[3]),
                        int.Parse(args[4]),
                        DateTime.Parse(args[5]),
                        args[6]));
                    }
                }
            }
            return workers.ToArray();
        }
    }
}
