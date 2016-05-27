using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise8._1;

namespace Exercite8._1
{
    public struct Fraction: IComparable
    {
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            _denominator = denominator;
            int gcd = Operation.GetGCD(numerator, denominator);
            if (gcd != 0)
            {
                Numerator = Numerator / gcd;
                Denominator = Denominator / gcd;
            }
        }

        public int Numerator { get; private set; }

        public int Denominator
        {
            get { return _denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("Знаменатель дроби не может быть равен нулю");
                }
                if (value < 0)
                {
                    _denominator = Math.Abs(value);
                    Numerator = Numerator*-1;
                }
                else
                {
                    _denominator = value;
                }
            }
        }

        public static Fraction CreateConsole()
        {
            Fraction value = new Fraction(Operation.GetInt(), Operation.GetPositiveInt());
            return value;
            
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
            if (fractionTwo.Numerator == 0)
            {
                throw new ArgumentNullException("Нельзя делить на ноль");
            }
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
    }
}
