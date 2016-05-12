using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercite7._2
{
    public struct Fraction: IComparable
    {
        private Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; private set; }

        public int Denominator { get; private set; }

        public static Fraction CreateConsole()
        {
            Fraction value = new Fraction(Program.GetInt(), Program.GetInt());
            return CastFraction(value);
        }

        public static Fraction Create(int numerator, int denominator)
        {
            Fraction value = new Fraction(numerator, denominator);
            return CastFraction(value);
        }

        public static Fraction CastFraction(Fraction value)
        {
            if (value.Numerator > 0)
            {
                int _GSD = Program.GetGCD(Math.Abs(value.Numerator), value.Denominator);
                value.Numerator = value.Numerator/_GSD;
                value.Denominator = value.Denominator/_GSD;
                return value;
            }
            else
            {
                value.Denominator = 1;
                return value;
            }
        }

        public static Fraction Addition(Fraction fractionOne, Fraction fractionTwo)
        {
            Fraction value =
                new Fraction(
                    fractionOne.Numerator*fractionTwo.Denominator + fractionTwo.Numerator*fractionOne.Denominator,
                    fractionOne.Denominator*fractionTwo.Denominator);
            return CastFraction(value);
        }

        public static Fraction Subtraction(Fraction fractionOne, Fraction fractionTwo)
        {
            Fraction value =
                new Fraction(
                    fractionOne.Numerator * fractionTwo.Denominator - fractionTwo.Numerator * fractionOne.Denominator,
                    fractionOne.Denominator * fractionTwo.Denominator);
            return CastFraction(value);
        }

        public static Fraction Multiplication(Fraction fractionOne, Fraction fractionTwo)
        {
            Fraction value = new Fraction(fractionOne.Numerator*fractionTwo.Numerator,
                fractionOne.Denominator*fractionTwo.Denominator);
            return CastFraction(value);
        }

        public static Fraction Division(Fraction fractionOne, Fraction fractionTwo)
        {
            Fraction value = new Fraction(fractionOne.Numerator*fractionTwo.Denominator,
                fractionOne.Denominator*fractionTwo.Numerator);
            return CastFraction(value);
        }

        public int CompareTo(object obj)
        {
            Fraction value = (Fraction) obj;
            if (value.Numerator*Denominator > value.Denominator*Numerator)
            {
                return -1;
            }
            if (value.Numerator * Denominator < value.Denominator * Numerator)
            {
                return 1;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }


        //Почему, если вызывать этот метод в Main, то в массиве оказываются одинаковые числа?
        //public static Fraction CreateRandom()
        //{
        //    Random random = new Random();
        //    Fraction value = new Fraction();
        //    value.Numerator = random.Next(-10, 10);
        //    value.Denominator = random.Next(1, 10);
        //    return CastFraction(value);
        //}
    }
}
