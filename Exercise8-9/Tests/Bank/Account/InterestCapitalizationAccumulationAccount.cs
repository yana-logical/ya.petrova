using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Account
{
    [TestClass]
    public class InterestCapitalizationAccumulationAccount
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InterestCapitalizationCloseAccount()
        {
            AccumulationAccount account = new AccumulationAccount(Guid.NewGuid(), 1000, 10, 10);
            account.Close();

            account.InterestCapitalization();
        }

        [TestMethod]
        public void InterestCapitalizationOneDayInMonth()
        {
            AccumulationAccountTest account = new AccumulationAccountTest(Guid.NewGuid(), 1000, 10, 10, new DateTime(2016, 05, 1));

            account.InterestCapitalization();
            bool success = (Math.Abs(1008.1967 - account.SumAccount) > 0.0001) ? false : true;

            Assert.AreEqual(success, true);
        }

        [TestMethod]
        public void InterestCapitalizationNoOneDayInMonth()
        {
            AccumulationAccountTest account = new AccumulationAccountTest(Guid.NewGuid(), 1000, 10, 10, new DateTime(2016, 05, 2));

            account.InterestCapitalization();
            bool success = (Math.Abs(1000 - account.SumAccount) > 0.0001) ? false : true;

            Assert.AreEqual(success, true);
        }

        private class AccumulationAccountTest : AccumulationAccount
        {
            private DateTime _date ;
            public AccumulationAccountTest(Guid number, double sumAccount, double initialFee, double interestRate, DateTime date)
                : base(number, sumAccount, initialFee, interestRate)
            {
                _date = date;
            }

            protected override DateTime NowDate
            {
                get { return _date; }
            }
        }
    }
}
