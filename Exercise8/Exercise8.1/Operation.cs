using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercite8._1
{
    public class Operation
    {
        public static int GetGCD(int numberOne, int numberTwo)
        {
            if (numberTwo != 0)
            {
                if (numberOne == numberTwo)
                {
                    return numberOne;
                }
                if (numberOne > numberTwo)
                {
                    return GetGCD(numberOne - numberTwo, numberTwo);
                }
                return GetGCD(numberTwo - numberOne, numberOne);
            }
            throw new ArgumentOutOfRangeException("Нельзя вычислить наибольший общий делитель, если одно из чисел - 0");
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

        public static int GetPreviousMonth()
        //Возращает номер предыдущего месяца
        {
            return (DateTime.Now.Month - 1 == 0) ? 12 : (DateTime.Now.Month - 1);
        }

        public static int GetYearOfPreviousMonth()
        //Возращает номер года предыдущего месяца
        {
            return (GetPreviousMonth() == 12) ? (DateTime.Now.Year - 1) : DateTime.Now.Year;
        }
    }
}
