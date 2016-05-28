using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Client
{
    [TestClass]
    public class GetSumAccountClient
    {

        [TestMethod]
        public void GetSumNormalAccountClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 2000);
            BaseAccount account3 = new SavingsAccount(Guid.NewGuid(), 3000);

            client.AddAccount(account1);
            client.AddAccount(account2);
            client.AddAccount(account3);

            Assert.AreEqual(1000, client.GetSumAccount(account1.Number));
            Assert.AreEqual(3000, client.GetSumAccount(account3.Number));
        }
    }
}
