using System;
using Exercite8._1;

namespace Exercise8._1
{
    /*Добавить проверку входных параметров и исключительные ситуации в задачи “Банковские счета” и “Дроби”*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете тип задачи: 1 - банк, 2 - дроби.");
            string typeTask = Console.ReadLine();

            if (typeTask == "1")
            {
                ProgramBank.MainBank();
            }
            if (typeTask == "2")
            {
                ProgramFraction.MainFraction();
            }
            else
            {
                Console.WriteLine("Введен неизвестный тип задачи");
            }
            Console.ReadKey();
        }
    }
}
