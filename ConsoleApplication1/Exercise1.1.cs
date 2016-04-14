using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввести с консоли 2 числа. Вывести их сумму на консоль
            int a;
            int b;
            int c;

            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            c = a + b;

            Console.WriteLine(c);
            Console.ReadKey();

        }
    }
}
