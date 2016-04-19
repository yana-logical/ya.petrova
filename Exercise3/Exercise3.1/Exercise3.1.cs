using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {

        //Сделать методы для считывания целых чисел, дробных чисел.
        //Сделать методы для вывода на консоль этих типов данных,
        //массивов целых и дробных чисел (можно доработать любое ДЗ).

        public static int GetInt()
        {
            int Number;
            if (int.TryParse(Console.ReadLine(), out Number))
            {
                return Number;
            }
            return 0;
        }


        public static double GetDouble()
        {
            double Number;
            if (double.TryParse(Console.ReadLine(), out Number))
            {
                return Number;
            }
            return 0;
        }


        public static void Print(int Number)
        {
            Console.WriteLine(Number);
        }


        public static void Print(double Number)
        {
            Console.WriteLine(Number);
        }





        static void Main(string[] args)
        {
            

        }
    }
}
