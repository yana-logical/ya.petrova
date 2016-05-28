using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Fractions
{
    [TestClass]
    public class DivisionFraction
    {
        [TestMethod]
        public void DivisionMiddleFraction()
        {
            Fraction fraction = new Fraction(4, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            Fraction fractionResult = fraction.Division(fractionTwo);

            Assert.AreEqual(2, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }

        public void DivisionMiddleNegativeFraction()
        {
            Fraction fraction = new Fraction(2, 4);
            Fraction fractionTwo = new Fraction(-2, 4);

            Fraction fractionResult = fraction.Division(fractionTwo);

            Assert.AreEqual(-1, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }

        public void DivisionBigFraction()
        {
            Fraction fraction = new Fraction(100000000, 1);
            Fraction fractionTwo = new Fraction(1, 2);

            Fraction fractionResult = fraction.Division(fractionTwo);

            Assert.AreEqual(200000000, fractionResult.Numerator);
            Assert.AreEqual(1, fractionResult.Denominator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DivisionNullFraction()
        {
            Fraction fraction = new Fraction(100000000, 1);
            Fraction fractionTwo = new Fraction(0, 2);

            Fraction fractionResult = fraction.Division(fractionTwo);
        }
    }
}
