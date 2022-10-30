using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countCards;
            int sum = 0;
            string input;

            Console.WriteLine(" Игра «21» \n Привет! \n Скажи сколько у тебя карт на руках?");
            Console.Write(" Количество карт: ");

            countCards = int.Parse(Console.ReadLine());

            Console.WriteLine(" - Ввод номинала карт");
            Console.WriteLine(" - Для карт с числовым номиналом вводите просто цифру. ");
            Console.WriteLine(" - Для остальных используйте буквы: ");
            Console.WriteLine(" Валет = J\r\n Дама = Q\r\n Король = K\r\n Туз = T ");

            for (int i = 0; i < countCards; i++)
            {
                Console.Write(" Введите номинал карты: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "K":
                    case "Q":
                    case "J":
                    case "T":
                        sum = sum + 10;
                        break;
                    default:
                        sum = sum + int.Parse(input);
                        break;
                }
            }

            Console.WriteLine($" Сумма всех карт равна: {sum}");

            Console.ReadKey();
        }
    }
}
