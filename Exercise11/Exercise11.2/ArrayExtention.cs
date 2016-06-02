using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise11._2
{
    public static class ArrayExtention
    {
        public static string ArrayToString(this int[] array, string delimiter)
        {
            string value = "";

            if (array == null)
            {
                throw new ArgumentNullException("Массив не может быть null");
            }
            foreach (int item in array)
            {
                value += item + delimiter;
            }
            value = value.Remove(value.Length - delimiter.Length, delimiter.Length);

            return value;
        }
    }
}
