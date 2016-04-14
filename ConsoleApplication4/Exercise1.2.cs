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
            //Ввести с консоли 2 числа: n и i. Вывести значение i-ого бита числа n
            int n;
            int i;
            int value;

            n = Convert.ToInt32(Console.ReadLine());
            i = Convert.ToInt32(Console.ReadLine());

            value = (n >> (i - 1)) & 1;

            Console.WriteLine(value);
            Console.ReadKey();

        }
    }
}
