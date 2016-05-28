using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GcdOperation
    {
        [TestMethod]
        public void GcdNegativeNumber()
        {
            int result = Operation.GetGCD(-5, 15);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GcdNullNumber()
        {
            int result = Operation.GetGCD(0, 15);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void GcdPositiveNumber()
        {
            int result = Operation.GetGCD(5, 15);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void GcdBigNumber()
        {
            int result = Operation.GetGCD(1000000000, 2000000000);

            Assert.AreEqual(1000000000, result);
        }
    }
}
