using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class YearOfPreviousMonthOperation
    {
        [TestMethod]
        public void YearOfPreviousMonthMay()
        {
            int result = Operation.GetYearOfPreviousMonth(new DateTime(2016, 5, 2));

            Assert.AreEqual(result, 2016);
        }

        [TestMethod]
        public void YearOfPreviousMonthJanuary()
        {
            int result = Operation.GetYearOfPreviousMonth(new DateTime(2016, 1, 2));

            Assert.AreEqual(result, 2015);
        }
    }
}
