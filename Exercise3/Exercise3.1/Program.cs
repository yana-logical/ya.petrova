using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3._1
{
    class Program
    {
        //Сделать методы для считывания целых чисел, дробных чисел.
        //Сделать методы для вывода на консоль этих типов данных,
        //массивов целых и дробных чисел (можно доработать любое ДЗ).

        public static int GetInt()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            return 0;
        }


        public static double GetDouble()
        {
            double number;
            if (double.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            return 0;
        }


        public static void Print(int number)
        {
            Console.WriteLine(number);
        }


        public static void Print(double number)
        {
            Console.WriteLine(number);
        }


        public static void Print(int[] array)
        {
            string strWrite = "";
            for (int i = 0; i < array.Length; i++)
            {
                strWrite = strWrite + array[i] + " ";
            }
            Console.WriteLine(strWrite);
        }


        public static void Print(double[] array)
        {
            string strWrite = "";
            for (int i = 0; i < array.Length; i++)
            {
                strWrite = strWrite + array[i] + " ";
            }
            Console.WriteLine(strWrite);
        }



        static void Main(string[] args)
        {
            int number;
            Random random = new Random();

            Console.WriteLine("Введите размер массива");
            number = GetInt();

            if (number > 0) 
            {
                int[] array = new int[number];

                for (int i = 0; i < number; i++)
                {
                    array[i] = random.Next(50);
                }

                Console.WriteLine("\n\rСгенеренный массив:");
                Print(array);
            }

            else
            {
                Console.WriteLine("\n\rВведена некорректная длина");
            }

            Console.ReadKey();
        }
    }
}
