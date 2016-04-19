using System;
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
            bool sign = false;
            Dictionary<int, int> symbols = new Dictionary<int, int>();

            Console.WriteLine("Введите числа через Enter\n\r");

            while (value != stopValue)
            {
                value = GetInt();
                if (!symbols.ContainsKey(value))
                {
                    symbols.Add(value, 1);
                }
                else
                {
                    symbols[value]++;
                }
            }

            foreach (KeyValuePair<int, int> kvp in symbols)
            {
                if (kvp.Value > 1)
                {
                    sign = true;
                    Console.WriteLine("Число '{0}' повторяется", kvp.Key);
                }
            }


            if (!sign)
            {
                Console.WriteLine("Повторяющихся значений нет");
            }

            Console.ReadKey();
        }
    }
}
