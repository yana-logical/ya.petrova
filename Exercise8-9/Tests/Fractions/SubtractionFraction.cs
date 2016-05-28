using System;
using System.Text;
using System.Collections.Generic;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Fractions
{
    [TestClass]
    public class SubtractionFraction
    {
        [TestMethod]
        public void SubtractionMiddleFraction()
        {
            Fraction fraction = new Fraction(4, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            Fraction fractionResult = fraction.Subtraction(fractionTwo);

            Assert.AreEqual(1, fractionResult.Numerator);
            Assert.AreEqual(2, fractionResult.Denominator);
        }

        public void SubtractionMiddleNegativeFraction()
        {
            Fraction fraction = new Fraction(2, 4);
            Fraction fractionTwo = new Fraction(-2, 4);

            Fraction fractionResult = fraction.Subtraction(fractionTwo);

            Assert.AreEqual(1, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }

        public void SubtractionBigFraction()
        {
            Fraction fraction = new Fraction(100000001, 1);
            Fraction fractionTwo = new Fraction(1, 1);

            Fraction fractionResult = fraction.Subtraction(fractionTwo);

            Assert.AreEqual(1, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }
    }
}
