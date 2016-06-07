using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise12._2
{
    public class Operation
    {
        public static int GetGCD(int numberOne, int numberTwo)
        {
            numberOne = Math.Abs(numberOne);
            numberTwo = Math.Abs(numberTwo);
            if (numberTwo == 0) return numberOne;
            if (numberOne == 0) return numberTwo;
            return GetGCD(numberTwo % numberOne, numberOne);
        }

        public static int GetInt()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            throw new ArgumentOutOfRangeException("Введенное значение не является числом");
        }

        public static int GetPositiveInt()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number) & number > 0)
            {
                return number;
            }
            throw new ArgumentOutOfRangeException("Введенное значение не является положительным числом");
        }

        public static double GetPositiveDouble()
        {
            double value;
            if (double.TryParse(Console.ReadLine(), out value) & value >= 0)
            {
                return value;
            }
            throw new ArgumentOutOfRangeException("Введенное значение не является положительным числом");
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

        public static int GetPreviousMonth(DateTime date)
        //Возращает номер предыдущего от пришедшего месяца
        {
            return (date.Month - 1 == 0) ? 12 : (date.Month - 1);
        }

        public static int GetYearOfPreviousMonth(DateTime date)
        //Возращает номер года предыдущего от пришедшего месяца
        {
            return (GetPreviousMonth(date) == 12) ? (date.Year - 1) : date.Year;
        }
    }
}
