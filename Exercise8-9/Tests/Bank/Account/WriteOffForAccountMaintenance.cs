using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Account
{
    [TestClass]
    public class WriteOffForAccountMaintenance
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WriteOffForAccountMaintenanceCloseAccount()
        {
            CheckingAccount account = new CheckingAccount(Guid.NewGuid(), 1000, 10);
            account.Close();

            account.WriteOffForAccountMaintenance();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WriteOffForAccountMaintenanceMinSum()
        {
            CheckingAccount account = new CheckingAccount(Guid.NewGuid(), 10, 100);

            account.WriteOffForAccountMaintenance();
        }

        [TestMethod]
        public void WriteOffForAccountMaintenanceOneDayInMonth()
        {
            CheckingAccountTest account = new CheckingAccountTest(Guid.NewGuid(), 1000, 10, new DateTime(2016, 05, 1));

            account.WriteOffForAccountMaintenance();

            Assert.AreEqual(account.SumAccount, 990);
        }

        [TestMethod]
        public void WriteOffForAccountMaintenanceNoOneDayInMonth()
        {
            CheckingAccountTest account = new CheckingAccountTest(Guid.NewGuid(), 1000, 10, new DateTime(2016, 05, 2));

            account.WriteOffForAccountMaintenance();

            Assert.AreEqual(account.SumAccount, 1000);
        }

        private class CheckingAccountTest : CheckingAccount
        {
            private DateTime _date;
            public CheckingAccountTest(Guid number, double sumAccount, double accountMaintenance, DateTime date)
                : base(number, sumAccount, accountMaintenance)
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
