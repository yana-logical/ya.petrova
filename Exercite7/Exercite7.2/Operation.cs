using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercite7._2
{
    public class Operation
    {
        public static int GetGCD(int numberOne, int numberTwo)
        {
            if (numberTwo != 0)
            {
                if (numberOne == numberTwo)
                {
                    return numberOne;
                }
                if (numberOne > numberTwo)
                {
                    return GetGCD(numberOne - numberTwo, numberTwo);
                }
                return GetGCD(numberTwo - numberOne, numberOne);
            }
            return 0;
        }
    }
}
