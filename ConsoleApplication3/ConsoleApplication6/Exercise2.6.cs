using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Калькулятор. С консоли вводится левый операнд, операция, правый операнд.
            //Выводится результат операции над операндами.
            //Реализовать как минимум 4 операции, обработку ошибок (деление на 0 и др).

            //А как проверить что пользователь ввел число?

            int a=0;
            int b=0;
            string str;
            string operation;
            int result = 0;
            bool sign=true;

            Console.WriteLine("Введите через Enter:" + "\n\r" +
                              "- первое число," + "\n\r" +
                              "- знак операции" + "\n\r" +
                              "- второе число." + "\n\r\n\r" +

                              "Допустимые операции:" + "\n\r" +
                              "- сложение (+)," + "\n\r" +
                              "- вычитание (-)," + "\n\r" +
                              "- умножение (*)," + "\n\r" +
                              "- деление (/)," + "\n\r" +
                              "- возведение в степень (^)" + "\n\r" +
                              "- остаток от деления (%)" + "\n\r");

            str = Console.ReadLine();
                try
                {
                    a = int.Parse(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число");
                    sign = false;
                }

            operation = Console.ReadLine();

            str = Console.ReadLine();
                try
                {
                    b = int.Parse(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число");
                    sign = false;
                }


            if (operation == "+")
            {
                result = a + b;
            }

            else if (operation == "-")
            {
                result = a - b;
            }

            else if(operation == "*")
            {
                result = a * b;
            }

            else if (operation == "/")
            {
                try
                {
                    result = a / b;
                }
                catch (Exception)
                {
                    Console.WriteLine("Результат: бесконечность");
                    sign = false;
                }
            }

            else if (operation == "^")
            {
                result = a ^ b;
            }

            else if (operation == "%")
            {
                result = a % b;
            }

            else
            {
                Console.WriteLine("Введена неизвестная операция");
                sign = false;
            }

            if (sign)
            {
                Console.WriteLine("Результат: " + result);
            }

            Console.ReadKey();

        }
    }
}
