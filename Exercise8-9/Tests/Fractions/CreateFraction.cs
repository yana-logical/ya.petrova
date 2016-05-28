using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CreateFraction
    {
        [TestMethod]
        public void CreateNoAboveFraction()
        {
            Fraction fraction = new Fraction(2, 4);

            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(2, fraction.Denominator);
        }

        [TestMethod]
        public void CreateFractionWithNegativeDenominator()
        {
            Fraction fraction = new Fraction(2, -4);

            Assert.AreEqual(-1, fraction.Numerator);
            Assert.AreEqual(2, fraction.Denominator);
        }

        [TestMethod]
        public void CreateFractionWithBigNumerator()
        {
            Fraction fraction = new Fraction(10000000, 1);

            Assert.AreEqual(10000000, fraction.Numerator);
            Assert.AreEqual(1, fraction.Denominator);
        }

        [TestMethod]
        public void CreateFractionWithBigDenominator()
        {
            Fraction fraction = new Fraction(1, 10000000);

            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(10000000, fraction.Denominator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateFractionWithNullDenominator()
        {
            Fraction fraction = new Fraction(2, 0);
        }
    }
}
