using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа");

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText(@"E:\work10.txt", Console.ReadLine()+"\n\r");
            }

            Console.WriteLine("\n\rВведенные числа:");
            Console.WriteLine(File.ReadAllText(@"E:\work10.txt"));
            
            Console.ReadKey();

            File.Delete(@"E:\work10.txt");
        }
    }
}
