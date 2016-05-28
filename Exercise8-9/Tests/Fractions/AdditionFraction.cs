using System;
using System.Text;
using System.Collections.Generic;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AdditionFraction
    {
        [TestMethod]
        public void AdditionMiddleFraction()
        {
            Fraction fraction = new Fraction(2, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            Fraction fractionResult = fraction.Addition(fractionTwo);

            Assert.AreEqual(1, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }

        public void AdditionMiddleNegativeFraction()
        {
            Fraction fraction = new Fraction(2, 4);
            Fraction fractionTwo = new Fraction(-2, 4);

            Fraction fractionResult = fraction.Addition(fractionTwo);

            Assert.AreEqual(0, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }

        public void AdditionBigFraction()
        {
            Fraction fraction = new Fraction(1, 1);
            Fraction fractionTwo = new Fraction(100000000, 1);

            Fraction fractionResult = fraction.Addition(fractionTwo);

            Assert.AreEqual(100000001, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }
    }
}

