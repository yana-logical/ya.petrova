using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Заполнить матрицу NxM случайными числами.
            //Из каждой строки выбрать минимальный элемент, занести его в массив.
            //Отсортировать полученный массив и вывести его значения в обратном порядке.

            int n;
            int m;
            string str="";
            Random random = new Random();

            Console.WriteLine("Введите количество строк в матрице");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов в матрице");
            m = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = new int[n,m];
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(10);
                    str = str + matrix[i, j] + " ";
                }
                Console.WriteLine(str + "\n\r");
                str = "";
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        array[i] = matrix[i, j];
                    }

                    if (array[i] > matrix[i,j])
                    {
                        array[i] = matrix[i, j];
                    }
                }
                str = str + array[i] + " ";
            }
            Console.WriteLine("Минимальные числа в строках: " + str);
            str = "";

            Array.Sort(array);

            for (int i = (n-1); i >= 0; i--)
            {
                str = str + array[i] + " ";
            }
            Console.WriteLine("Отсортированные минимальные числа " + str);

            Console.ReadKey();
        }
    }
}
