using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввести с консоли N чисел.
            //Вывести сумму, максимальное, минимальное значения, количество четных чисел, произведение нечетных чисел.
            int n;
            int number;
            int max = 0;
            int min = 0;
            int count = 0;
            int composition = 1;

            Console.WriteLine("Введите количество чисел");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите числа");

            for (int i = 0; i < n; i++)
            {
                number = Convert.ToInt32(Console.ReadLine());

                if (i == 0)
                {
                    max = number;
                    min = number;
                }

                if (max < number)
                {
                    max = number;
                }

                if (min > number)
                {
                    min = number;
                }

                if (number % 2 == 0)
                {
                    count++;
                }

                if (number % 2 == 1)
                {
                    composition = composition * number;
                }
            }

            Console.WriteLine("Минимальное значение = " + min + "\r\n\r\n" +
                                "Максимальное значение = " + max + "\r\n\r\n" +
                                "Количество четных числе = " + count + "\r\n\r\n"+
                                "Произведение нечетных = " + composition);
            Console.ReadKey();
        }
    }
}
