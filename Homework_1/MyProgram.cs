using System;

namespace Homework_1
{
    public class MyProgram
    {
        static void Main(string[] args)
        {
            Person person = new Person("Боровихин Владислав Евгеньевич", "Vborovih@bk.ru", 22, 4.7f, 4.1f, 3.6f);
            Console.Write(person.GetInfo());
            Console.ReadKey();

            Console.Write(person.GetInfoAvgScore());
            Console.ReadKey();
        }
    }
}
