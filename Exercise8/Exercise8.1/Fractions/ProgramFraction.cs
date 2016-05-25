using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercite8._1;

namespace Exercise8._1
{
    public static class ProgramFraction
    {
        public static void MainFraction()
        {
            int count = 0;
            Console.WriteLine("Введите количество дробей в массиве");
            try
            {
                count = Operation.GetInt();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Fraction sum = new Fraction(0, 1);
            Fraction[] array = new Fraction[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                Fraction value = new Fraction(random.Next(-10, 10), random.Next(1, 10));
                array[i] = value;
                Console.WriteLine(array[i]);
            }

            Array.Sort(array);

            Console.WriteLine("\r\nОтсортированный массив:\r\n");
            Operation.PrintArray(array);

            for (int i = 0; i < count; i++)
            {
                sum = sum.Addition(array[i]);
            }

            Console.WriteLine("\r\nСумма дробей = " + sum);

            Console.ReadKey();
        }
    }
}
