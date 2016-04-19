using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3._2
{
    class Program
    {
        //Считать строку с консоли.
        //Создать словарь, где ключом будет символ строки, а значением - количество данных символов в считанной строке.

        public static string GetString()
        {
            Console.WriteLine("Введите строку");
            string value = Console.ReadLine();
            return value;
        }

        public static void Dictionary(string value)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                if (!symbols.ContainsKey(value[i]))
                {
                    symbols.Add(value[i], 1);
                }
                else
                {
                    symbols[value[i]]++;
                }
            }
            Console.WriteLine("\n\rКоличество символов в фразе:");

            foreach (KeyValuePair<char, int> kvp in symbols)
            {
                Console.WriteLine("Кол-во '{0}'={1}", kvp.Key, kvp.Value);
            }
        }

        static void Main(string[] args)
        {
            string value = GetString();
            Dictionary(value);
            Console.ReadKey();
        }
    }
}
