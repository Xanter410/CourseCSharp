using System;
using System.Xml.Linq;

namespace Homework_7_Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement myPERSON = new XElement("Person");
            XElement myADDRESS = new XElement("Address");
            XElement myPHONES = new XElement("Phones");

            Console.WriteLine("Заполнение данных о контакте.");

            XAttribute xAttributeFullName = new XAttribute("name", UserRequest("Введите ФИО:"));
            myPERSON.Add(xAttributeFullName);

            myADDRESS.Add(new XElement("Street", UserRequest("Введите улицу:")));
            myADDRESS.Add(new XElement("HouseNumber", UserRequest("Введите номер дома:")));
            myADDRESS.Add(new XElement("FlatNumber", UserRequest("Введите номер квартиры:")));

            myPERSON.Add(myADDRESS);

            myPHONES.Add(new XElement("MobilePhone", UserRequest("Введите номер мобильного телефона:")));
            myPHONES.Add(new XElement("FlatPhone", UserRequest("Введите номер домашнего телефона:")));

            myPERSON.Add(myPHONES);

            myPERSON.Save("_myContact.xml");
        }

        /// <summary>
        /// Запрос данных у пользователя
        /// </summary>
        /// <returns>Возвращает string</returns>
        static private string UserRequest(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

    }
}
