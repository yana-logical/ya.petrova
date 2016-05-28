using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Account
{
    [TestClass]
    public class WithdrawalsMetalAccount
    {
        [TestMethod]
        public void MiddleSumWithdrawalsMiddleSumMetalAccount()
        {
            MetalAccount account = new MetalAccount(Guid.NewGuid(), 1000, "золото", 100);

            account.Withdrawals(100);

            Assert.AreEqual(900, account.SumAccount);
            Assert.AreEqual(9, account.AmountGrams);
        }

        [TestMethod]
        public void MiddleSumWithdrawalsBigSumMetalAccount()
        {
            MetalAccount account = new MetalAccount(Guid.NewGuid(), 10000000000000, "золото", 100);

            account.Withdrawals(1);

            Assert.AreEqual(9999999999999, account.SumAccount);
            Assert.AreEqual(99999999999.99, account.AmountGrams);
        }
    }
}
