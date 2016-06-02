using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11._2
{
    class Program
    {
        /*Написать метод-расширение для массива целых чисел, который принимает как параметр строку-разделитель, а возвращает строку,
        в которой содержатся все элементы массива, перечисленные через указанный разделитель.*/
        static void Main(string[] args)
        {
            var array = new int[10];
            Random random = new Random();
            string value;
            string delimiter;

            for (int i = 0; i < 10; i++)
            {
                array[i] = random.Next(10);
            }

            Console.WriteLine("Введите разделитель");
            delimiter = Console.ReadLine();

            try
            {
                value = array.ArrayToString(delimiter);
                Console.WriteLine("Полученная строка:");
                Console.WriteLine(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
           

            Console.ReadKey();

        }
    }
}
