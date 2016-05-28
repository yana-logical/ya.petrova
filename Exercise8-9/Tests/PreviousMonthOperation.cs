using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PreviousMonthOperation
    {
        [TestMethod]
        public void PreviousMonthMay()
        {
            int result = Operation.GetPreviousMonth(new DateTime(2016, 5, 2));

            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void PreviousMonthJanuary()
        {
            int result = Operation.GetPreviousMonth(new DateTime(2016, 1, 2));

            Assert.AreEqual(result, 12);
        }
    }
}
