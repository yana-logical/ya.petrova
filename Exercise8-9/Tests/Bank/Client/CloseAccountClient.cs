using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Client
{
    [TestClass]
    public class CloseAccountClient
    {
        [TestMethod]
        public void GetSumNormalAccountClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");
            BaseAccount account = new SavingsAccount(Guid.NewGuid(), 0);

            client.AddAccount(account);
            client.CloseAccount(account.Number);

            Assert.AreEqual(false, account.IsActiveAccount);
        }
    }
}
