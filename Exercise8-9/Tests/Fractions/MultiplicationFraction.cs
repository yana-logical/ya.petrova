using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Fractions
{
    [TestClass]
    public class MultiplicationFraction
    {
        [TestMethod]
        public void MultiplicationMiddleFraction()
        {
            Fraction fraction = new Fraction(4, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            Fraction fractionResult = fraction.Multiplication(fractionTwo);

            Assert.AreEqual(1, fractionResult.Numerator);
            Assert.AreEqual(2, fractionResult.Denominator);
        }

        public void MultiplicationMiddleNegativeFraction()
        {
            Fraction fraction = new Fraction(2, 4);
            Fraction fractionTwo = new Fraction(-2, 4);

            Fraction fractionResult = fraction.Multiplication(fractionTwo);

            Assert.AreEqual(-1, fractionResult.Numerator);
            Assert.AreEqual(2, fractionResult.Denominator);
        }

        public void MultiplicationBigFraction()
        {
            Fraction fraction = new Fraction(100000000, 1);
            Fraction fractionTwo = new Fraction(1, 1);

            Fraction fractionResult = fraction.Multiplication(fractionTwo);

            Assert.AreEqual(100000000, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }
    }
}
