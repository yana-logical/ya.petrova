using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Client
{
    [TestClass]
    public class AddAccountClient
    {
        [TestMethod]
        public void AddNormalAccountClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 2000);
            BaseAccount account3 = new SavingsAccount(Guid.NewGuid(), 3000);

            client.AddAccount(account1);
            client.AddAccount(account2);
            client.AddAccount(account3);

            Assert.AreEqual(3, client.GetAllAccount().Count);
            Assert.AreEqual(6000, client.GetSumAllAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddMoreMaxCountAccountAccountClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 2000);
            BaseAccount account3 = new SavingsAccount(Guid.NewGuid(), 3000);
            BaseAccount account4 = new SavingsAccount(Guid.NewGuid(), 4000);

            client.AddAccount(account1);
            client.AddAccount(account2);
            client.AddAccount(account3);
            client.AddAccount(account4);
        }
    }
}
