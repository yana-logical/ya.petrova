using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Преобразовать класс “Телефон” на работу со свойствами

            Console.WriteLine("Введите код города и телефона через Enter");

            string cityCode = Console.ReadLine();
            string phoneNuber = Console.ReadLine();

            Phone phone1 = new Phone(cityCode, phoneNuber);

            Console.WriteLine();
            Console.WriteLine(phone1.GetPhone);
            Console.ReadKey();
        }
    }
}
