using System;
using System.Text;
using System.Collections.Generic;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WithdrawalsAccount
    {
        [TestMethod]
        public void MiddleSumWithdrawalsMiddleSumAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);

            account.Withdrawals(100);

            Assert.AreEqual(900, account.SumAccount);
        }

        [TestMethod]
        public void MiddleSumWithdrawalsBigSumAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 10000000000000);

            account.Withdrawals(1);

            Assert.AreEqual(9999999999999, account.SumAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithdrawalsNegativeSum()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);

            account.Withdrawals(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WithdrawalsCloseAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);
            account.Close();

            account.Withdrawals(100);
        }
    }
}
