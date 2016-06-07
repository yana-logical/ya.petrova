using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12._2
{
    class Program
    {
        /*Создать коллекцию из 100 случайных дробей.
        Выбрать все дроби, которые являются целым числом. Вывести на консоль их как целые числа.*/
        static void Main(string[] args)
        {
            var random = new Random();

            var collectionAll = Enumerable.Range(0, 10)
                .Select(f => new Fraction(random.Next(20), random.Next(20)+1));

            var collectionInt = collectionAll.Where(f => f.Numerator%f.Denominator == 0)
            .Select(f => new
            {
                fraction = f,
                fractionInt = f.Numerator / f.Denominator
            });

            Console.WriteLine("Дроби:");

            foreach (var fraction in collectionAll)
            {
                Console.WriteLine(fraction);
            }

            Console.WriteLine("Целые числа:");

            foreach (var c in collectionInt)
            {
                Console.WriteLine(c.fractionInt);
            }

            Console.ReadKey();
        }
    }
}
