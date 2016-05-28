using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Fractions
{
    [TestClass]
    public class CompareToFraction
    {
        [TestMethod]
        public void CompareToMiddleFraction()
        {
            Fraction fraction = new Fraction(4, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            int result = fraction.CompareTo(fractionTwo);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareToNegativeFraction()
        {
            Fraction fraction = new Fraction(-4, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            int result = fraction.CompareTo(fractionTwo);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareToEqualFraction()
        {
            Fraction fraction = new Fraction(2, 4);
            Fraction fractionTwo = new Fraction(2, 4);

            int result = fraction.CompareTo(fractionTwo);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareToBigFraction()
        {
            Fraction fraction = new Fraction(200000000, 4);
            Fraction fractionTwo = new Fraction(199999999, 4);

            int result = fraction.CompareTo(fractionTwo);

            Assert.AreEqual(1, result);
        }
    }
}
