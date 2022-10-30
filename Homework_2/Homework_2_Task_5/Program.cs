using System;

namespace Homework_2_Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string input;
            int numInput;
            int length;
            int numRand;

            Console.Write("Вам предстоит угадать случайное число из последовательности. " +
                          "\nНо для начала введите максимальное число диапазона: ");
            length = int.Parse(Console.ReadLine());

            numRand = random.Next(0, length);

            do
            {
                Console.Write("Угадайте загаданное программой число: ");
                input = Console.ReadLine();

                if (input == "")
                {
                    Console.WriteLine($"Жаль, что вы не смогли отгадать число. Загаданное число: {numRand}");
                    break;
                }

                numInput = int.Parse(input);

                if (numInput > numRand)
                {
                    Console.WriteLine("Введенное число БОЛЬШЕ загаданного.");
                }
                else if (numInput < numRand)
                {
                    Console.WriteLine("Введенное число МЕНЬШЕ загаданного.");
                }
                else
                {
                    Console.WriteLine("Вы угадали загаданное число! Поздравляем!");
                    break;
                }
            } while (true);

            Console.WriteLine("Игра закончена.");
            Console.ReadKey();
        }
    }
}
