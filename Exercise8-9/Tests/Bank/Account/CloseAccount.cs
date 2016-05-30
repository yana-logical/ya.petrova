using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Account
{
    [TestClass]
    public class CloseAccount
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CloseAccountPositiveSum()
        {
            SavingsAccount account = new SavingsAccount(Guid.NewGuid(), 1000);

            account.Close();
        }

        [TestMethod]
        public void CloseAccountZeroSum()
        {
            SavingsAccount account = new SavingsAccount(Guid.NewGuid(), 0);

            account.Close();

            Assert.AreEqual(false, account.IsActiveAccount);
        }
    }
}
