using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Заполнить 2 матрицы размерности NxN случайными числами.
            //Вывести на консоль. Сложить 2 матрицы. Вывести результат.
            int n;
            string str="";

            Console.WriteLine("Введите размер матрицы");
            n = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            int[,] value = new int[n,n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix1[i, j] = random.Next(10);
                    matrix2[i, j] = random.Next(10);
                }
            }

            Console.WriteLine("Первая матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str = str + " " + matrix1[i, j];
                }

                Console.WriteLine(str);
                str = "";
            }

            Console.WriteLine("Вторая матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str = str + " " + matrix2[i, j];
                }

                Console.WriteLine(str);
                str = "";
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        value[i, j] = value[i, j] + matrix1[i, k] * matrix2[k, j];
                    }
                }

            }

            Console.WriteLine("Результирующая матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str = str + " " + value[i, j];
                }

                Console.WriteLine(str);
                str = "";
            }


            Console.ReadKey();
        }
    }
}
