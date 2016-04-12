using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program1_1
    {
        static void Main(string[] args)
        {
            //Задание 1.1
            //int a;
            //int b;
            //int c;

            //a = Convert.ToInt32(Console.ReadLine());
            //b = Convert.ToInt32(Console.ReadLine());

            //c = a + b;

            //Console.WriteLine(c);
            //Console.ReadKey();


            //Задание 1.2
            //int n;
            //int i;
            //int value;

            //n = Convert.ToInt32(Console.ReadLine());
            //i = Convert.ToInt32(Console.ReadLine());

            //value = (n >> (i - 1)) & 1;

            //Console.WriteLine(value);
            //Console.ReadKey();

            //Задание 1.3
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
