using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Client
{
    [TestClass]
    public class CompareToClient
    {
        [TestMethod]
        public void CompareToClientMore()
        {
            BaseClient client1 = new NormalClient(Guid.NewGuid(), "Владелец1");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            client1.AddAccount(account1);
            BaseClient client2 = new NormalClient(Guid.NewGuid(), "Владелец2");
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 2000);
            client2.AddAccount(account2);

            int result = client1.CompareTo(client2);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareToClientLess()
        {
            BaseClient client1 = new NormalClient(Guid.NewGuid(), "Владелец1");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 2000000);
            client1.AddAccount(account1);
            BaseClient client2 = new NormalClient(Guid.NewGuid(), "Владелец2");
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 1000);
            client2.AddAccount(account2);

            int result = client1.CompareTo(client2);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void CompareToClientEqually()
        {
            BaseClient client1 = new NormalClient(Guid.NewGuid(), "Владелец1");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            client1.AddAccount(account1);
            BaseClient client2 = new NormalClient(Guid.NewGuid(), "Владелец2");
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 1000);
            client2.AddAccount(account2);

            int result = client1.CompareTo(client2);

            Assert.AreEqual(0, result);
        }
    }
}
