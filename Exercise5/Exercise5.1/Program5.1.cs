using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    //Реализовать классы для описания клиентов двух типов: ИП и ООО.
    //Каждый тип клиента имеет идентификатор, основной телефон, сумма заказа.
    //У ИП указывается ФИО, дата рождения.
    //У ООО указывается название, банковский счет.
    //Реализовать метод, который возвращает отформатированное название и сумму заказа.

    class Program
    {
        public static int GetInt()
        {
            int value;
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            else
            {
                return 0;
            }

        }

        public static double GetDouble()
        {
            double value;
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public static DateTime GetDateTime()
        {
            DateTime value;
            if (DateTime.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        public static string FormatName(int type, string name, double sumOrder)
        {
            string formatName = null;
            if (type == 1)
            {
                formatName = "На счету ИП " + name + " находится " + sumOrder + " рублей";
            }
            else if (type == 2)
            {
                formatName = "На счету ООО " + name + " находится " + sumOrder + " рублей";
            }
            return formatName;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите тип клиента (1 - ИП, 2 - ООО)");
            int type = GetInt();

            if (type == 1)
            {
                Console.WriteLine("Введите через Enter: телефон, сумму заказа, фамилия, имя, отчество, дату рождения");
                SoleProprietor soleProprietor = new SoleProprietor();
                string name = soleProprietor.FormatName();
                Console.WriteLine(FormatName(type: type, name: name, sumOrder: soleProprietor.SumOrder));
            }
            else if (type == 2)
            {
                Console.WriteLine("Введите через Enter: телефон, сумму заказа, наименование организации, номер счета");
                LegalEntity legalEntity = new LegalEntity();
                Console.WriteLine(FormatName(type: type, name: legalEntity.NameLegalEntity, sumOrder: legalEntity.SumOrder));
            }
            else
            {
                Console.WriteLine("Введено некорректное значение");
            }

            Console.ReadKey();
        }
    }

    //Как заставить вводить значение повторно при ошибке?
    
}
