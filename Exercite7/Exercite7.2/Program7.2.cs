using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercite7._2
{
    /* Реализовать неизменяемую структуру - простая дробь (x/y).
    Числитель и знаменатель - целые числа.
    Знаменатель - всегда положительный.
    Ноль - 0/x.
    Реализовать операции сложения, вычитания, умножения, деления.
    Реализовать интерфейс IComparable.
    Создать массив из N случайных дробей, отсортировать по возрастанию.
    Найти сумму всех дробей.
    
        *Сделать дробь не сокращаемой. Т.е. 2/4 -> 1/2, 50/15 -> 10/3, 0/7 -> 0/1 и т.д */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество дробей в массиве");
            int count = GetInt();
            Fraction sum = Fraction.Create(0, 1);
            Fraction[] array = new Fraction[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                Fraction value = new Fraction();
                value = Fraction.Create(random.Next(-10, 10), random.Next(1, 10));
                array[i] = value;
                Console.WriteLine(array[i]);
            }

            Array.Sort(array);

            Console.WriteLine("\r\nОтсортированный массив:\r\n");
            PrintArray(array);

            for (int i = 0; i < count ; i++)
            {
                sum = sum.Addition(array[i]);
            }

            Console.WriteLine("\r\nСумма дробей = " + sum);

            Console.ReadKey();
        }

        public static int GetInt()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            return 0;
        }

        public static int GetPositiveInt()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number) & number > 0)
            {
                return number;
            }
            return 0;
        }

        public static void PrintArray(Fraction[] array)
        {
            string value = "";
            for (int i = 0; i < array.Length; i++)
            {
                value += array[i] + "   ";
            }
            Console.WriteLine(value);
        }

         
        //for (int i = 0; i<count; i++)
        //    {
        //        array[i] = Fraction.CreateRandom();
        //        Console.WriteLine(array[i]);
        //    }

}
}
