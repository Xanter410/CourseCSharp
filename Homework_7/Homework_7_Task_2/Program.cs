using System;
using System.Collections.Generic;

namespace Homework_7_Task_2
{
    internal class Program
    {
        static private Dictionary<string, string> _phoneBook = new Dictionary<string, string>();

        static private void Main(string[] args)
        {
            showMenu();
        }

        static private void showMenu()
        {
            while (true)
            {

                Console.WriteLine("- - - - - - - Меню - - - - - - -");
                Console.WriteLine("1 - Посмотреть телефонную книгу.");
                Console.WriteLine("2 - Ввести номера телефонов и их владельцев.");
                Console.WriteLine("3 - Найти владельца по номеру телефона.");
                Console.WriteLine("4 - Закрыть приложение.");
                Console.WriteLine("- - - - - - - - - - - - - - - -");
                Console.Write("Введите номер действия: ");


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1: Console.WriteLine(); ShowPhoneBook(); break;
                    case ConsoleKey.D2: Console.WriteLine(); ShowAddMenu(); break;
                    case ConsoleKey.D3: Console.WriteLine(); ShowFindMenu(); break;

                    case ConsoleKey.Escape:
                    case ConsoleKey.D4: Environment.Exit(0); break;
                    default: break;
                }
            }

        }

        static private void ShowAddMenu()
        {
            string phoneNumber;
            string fullName;

            Console.WriteLine("- - - - Ввод новых данных - - - -");
            Console.WriteLine("   Чтобы прекратить ввод текста  ");
            Console.WriteLine("      введите пустую строку      ");
            Console.WriteLine("- - - - - - - - - - - - - - - - -");

            while (true)
            {
                Console.Write("Введите номер телефона: ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber == "") break;

                Console.Write("Введите ФИО владельца: ");
                fullName = Console.ReadLine();
                if (fullName == "") break;


                if(AddNewEntries(phoneNumber, fullName))
                {
                    Console.WriteLine("Новая запись успешно добавлена.\n");
                }
                else
                {
                    Console.WriteLine("Данный номер телефона уже есть в телефонной книге.\n");
                }
            }
        }

        static private void ShowFindMenu()
        {
            string phoneNumber;
            string fullName;

            Console.WriteLine("- - - - Поиск по номеру - - - - -");
            Console.WriteLine("   Чтобы прекратить ввод текста  ");
            Console.WriteLine("      введите пустую строку      ");
            Console.WriteLine("- - - - - - - - - - - - - - - - -");

            while (true)
            {
                Console.Write("Введите номер телефона: ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber == "") break;

                fullName = FindPersonByPhoneNum(phoneNumber);
                if (fullName != null)
                {
                    Console.WriteLine($"Найдено имя: {fullName}");
                }
                else
                {
                    Console.WriteLine("Пользователь по данному номеру телефона не найден.");
                }

                
            }
        }

        static private void ShowPhoneBook()
        {
            if (_phoneBook.Count == 0)
            {
                Console.WriteLine("Телефонная книга пуста.");
            }
            foreach (var item in _phoneBook)
            {
                Console.WriteLine($"Номер: {item.Key}, Владелец: {item.Value}");
            }
        }

        static private bool AddNewEntries(string phoneNumber, string fullName)
        {
            if (!_phoneBook.ContainsKey(phoneNumber))
            {
                _phoneBook.Add(phoneNumber, fullName);
                return true;
            }
            else
            {
                return false;
            }
        }

        static private string FindPersonByPhoneNum(string phoneNumber)
        {
            if (_phoneBook.TryGetValue(phoneNumber, out string fullName))
            {
                return fullName;
            }
            return null;
        }
    }
}
