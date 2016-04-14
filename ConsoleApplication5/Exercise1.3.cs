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
            //Ввести с консоли число. Обнулить последний бит этого число. Вывести на консоль
            int n;
            int value;

            n = Convert.ToInt32(Console.ReadLine());

            value = n >> 1;
            value = value << 1;

            Console.WriteLine(value);
            Console.ReadKey();

        }
    }
}
