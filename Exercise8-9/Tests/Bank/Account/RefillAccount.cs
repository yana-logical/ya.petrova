using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RefillAccount
    {
        [TestMethod]
        public void MiddleSumRefillMiddleSumAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);

            account.Refill(100);

            Assert.AreEqual(1100, account.SumAccount);
        }

        [TestMethod]
        public void BigSumRefillMiddleSumAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);

            account.Refill(10000000000000);

            Assert.AreEqual(10000000001000, account.SumAccount);
        }

        [TestMethod]
        public void MiddleSumRefillBigSumAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 10000000000000);

            account.Refill(1000);

            Assert.AreEqual(10000000001000, account.SumAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RefillNegativeSum()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);

            account.Refill(-100);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RefillCloseAccount()
        {
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 1000);
            account.Close();

            account.Refill(100);
        }
    }
}
