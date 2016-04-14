using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Заполнить массив длиной N случайными числами. Ввести с консоли число A. Вывести Yes, если число A есть в массиве, No - в противном случае.

            int n;
            int a;
            bool sign = false;
            string str="";
            Random random = new Random();

            Console.WriteLine("Введите длину массива");
            n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(10);
                str = str + array[i] + " ";
            }

            Console.WriteLine("Сгенерированный массив: " + str + "\r\n");

            Console.WriteLine("Введите число А");

            a = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (a == array[i])
                {
                    sign=true;
                    Console.WriteLine("Yes");
                    break;
                }
                
            }

            if (!sign)
            {
                Console.WriteLine("No");
            }

            Console.ReadKey();
        }
    }
}
