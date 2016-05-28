using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Account
{
    [TestClass]
    public class RefillMetalAccount
    {
        [TestMethod]
        public void MiddleSumRefillMiddleSumMetalAccount()
        {
            MetalAccount account = new MetalAccount(Guid.NewGuid(), 1000, "золото", 100);

            account.Refill(100);

            Assert.AreEqual(1100, account.SumAccount);
            Assert.AreEqual(11, account.AmountGrams);
        }

        [TestMethod]
        public void BigSumRefillMiddleSumMetalAccount()
        {
            MetalAccount account = new MetalAccount(Guid.NewGuid(), 1000, "золото", 100);

            account.Refill(10000000000000);

            Assert.AreEqual(10000000001000, account.SumAccount);
            Assert.AreEqual(100000000010, account.AmountGrams);
        }

        [TestMethod]
        public void MiddleSumRefillBigSumMetalAccount()
        {
            MetalAccount account = new MetalAccount(Guid.NewGuid(), 10000000000000, "золото", 100);

            account.Refill(1000);

            Assert.AreEqual(10000000001000, account.SumAccount);
            Assert.AreEqual(100000000010, account.AmountGrams);
        }
    }
}
