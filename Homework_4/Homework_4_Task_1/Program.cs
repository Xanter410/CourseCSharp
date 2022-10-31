using System;
using System.Collections.Generic;

namespace Homework_4_Task_1
{
    internal class Program
    {
        static public string[] SplitString(string input)
        {
            List<string> ResultList = new List<string>();
            var begining = 0;
            var len = input.Length;

            for (var index = 0; index < len; index++)
            {
                if (input[index] == ' ')
                {
                    ResultList.Add(input.Substring(begining, index - begining));
                    begining = index + 1;
                }
            }
            ResultList.Add(input.Substring(begining));

            return ResultList.ToArray();
        }

        static public void PrintArrayWords(string[] array)
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое предложение из нескольких слов: ");
            string input = Console.ReadLine();

            PrintArrayWords(SplitString(input));

            Console.ReadKey();
        }
    }
}
