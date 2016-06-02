using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11._1
{
    public static class ArrayExtention
    {
        public static void PrintArray(this Array array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Массив не может быть null");
            }
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
