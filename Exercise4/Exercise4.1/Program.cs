using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создать класс “Телефон”, который содержит следующие данные:
            //код города, номер телефона, которые не могут быть изменены. 
            //Добавить метод, который возвращает строку вида “(999) 999999” или “999999”, если код города отсутствует.

            Console.WriteLine("Введите код города и телефона через Enter");

            string cityCode = Console.ReadLine();
            string phoneNuber = Console.ReadLine();

            Phone phone1 = new Phone(cityCode, phoneNuber);

            Console.WriteLine();
            Console.WriteLine(phone1.GetPhone());
            Console.ReadKey();

        }
    }
}
