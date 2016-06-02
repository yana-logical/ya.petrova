using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[4];
            int[] arrayNull = null;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            try
            {
                int q = arrayNull.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();

            try
            {
                array.PrintArray();
                arrayNull.PrintArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
