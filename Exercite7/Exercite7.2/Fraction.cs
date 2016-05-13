using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercite7._2
{
    public struct Fraction: IComparable
    {
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            _denominator = denominator;
            int gsd = Operation.GetGCD(Math.Abs(numerator), denominator);
            if (gsd != 0)
            {
                Numerator = Numerator / gsd;
                _denominator = _denominator / gsd;
            }
        }

        public int Numerator { get; private set; }

        public int Denominator
        {
            get { return _denominator; }
            private set { _denominator = Math.Abs(value); }
        }

        public static Fraction CreateConsole()
        {
            Fraction value = new Fraction(Program.GetInt(), Program.GetInt());
            return value;
        }

        public static Fraction Create(int numerator, int denominator)
        {
            Fraction value = new Fraction(numerator, denominator);
            return value;
        }

        public static Fraction CastFraction(Fraction value)
        {
            if (value.Numerator > 0)
            {
                int gsd = Operation.GetGCD(Math.Abs(value.Numerator), value.Denominator);
                value.Numerator = value.Numerator/gsd;
                value.Denominator = value.Denominator/gsd;
                return value;
            }
            else
            {
                value.Denominator = 1;
                return value;
            }
        }

        public Fraction Addition(Fraction fractionTwo)
        {
            Fraction value =
                new Fraction(
                    Numerator*fractionTwo.Denominator + fractionTwo.Numerator*Denominator,
                    Denominator*fractionTwo.Denominator);
            return value;
        }

        public Fraction Subtraction(Fraction fractionTwo)
        {
            Fraction value =
                new Fraction(
                    Numerator*fractionTwo.Denominator - fractionTwo.Numerator*Denominator,
                    Denominator*fractionTwo.Denominator);
            return value;
        }

        public Fraction Multiplication(Fraction fractionTwo)
        {
            Fraction value = new Fraction(Numerator*fractionTwo.Numerator,
                Denominator*fractionTwo.Denominator);
            return value;
        }

        public Fraction Division(Fraction fractionTwo)
        {
            Fraction value = new Fraction(Numerator*fractionTwo.Denominator,
                Denominator*fractionTwo.Numerator);
            return value;
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
