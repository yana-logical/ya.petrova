using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Заполнить с консоли массив из N элементов. Отсортировать.
            //Вывести результат. N - задается с консоли

            int n;

            Console.WriteLine("Введите количество символов");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите символы");

            int[] value = new int[n];

            for (int i = 0; i < n; i++)
            {
                value[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(value);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(value[i]);
            }

            Console.ReadKey();
        }
    }
}
