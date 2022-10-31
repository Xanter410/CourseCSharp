using System;
using System.Linq;

namespace Homework_4_Task_2
{
    internal class Program
    {
        static public string[] SplitString(string input)
        { 
            return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        static public string ReversWords(string input)
        {
            string[] words = SplitString(input);

            return string.Join(" ", words.Reverse());
        }

        static private void Main(string[] args)
        {
            Console.WriteLine("Введите любое предложение из нескольких слов: ");
            string input = Console.ReadLine();

            Console.WriteLine(ReversWords(input));

            Console.ReadKey();
        }
    }
}
