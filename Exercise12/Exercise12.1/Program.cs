using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12._1
{
    class Program
    {
        /*Создать массив из 10 числе. Вывести на экран с помощью LINQ только четные или те, что больше 5.
        Отсортировать по убыванию.*/
        static void Main(string[] args)
        {
            var array = new int[10];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10);
            }

            var result = array.Where(u => (u%2 == 0) || (u > 5)).OrderByDescending(u => u);

            foreach (var a in array)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Результат:");

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }

            Console.ReadKey();
        }
    }
}
