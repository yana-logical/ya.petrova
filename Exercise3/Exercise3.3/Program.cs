﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3._3
{
    class Program
    {
        //Считывать с консоли числа, пока не будет введено число “-1”,
        //среди введенных чисел вывести все дублирующиеся.

        public static int GetInt()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            int stopValue = -1;
            int value = stopValue+1;
            HashSet<int> symbolsAll = new HashSet<int>();
            HashSet<int> symbolsDublicate = new HashSet<int>();

            Console.WriteLine("Введите числа через Enter\n\r");

            while (value != stopValue)
            {
                value = GetInt();
                if (symbolsAll.Contains(value))
                {
                    symbolsDublicate.Add(value);
                }
                else
                {
                    symbolsAll.Add(value);
                }
            }

            

            if (symbolsDublicate.Count != 0)
            {
                foreach (int element in symbolsDublicate)
                {
                    Console.WriteLine("Число '{0}' повторяется", element);
                }
            }
            else
            {
                Console.WriteLine("Повторяющихся значений нет");
            }

            Console.ReadKey();
        }
    }
}
