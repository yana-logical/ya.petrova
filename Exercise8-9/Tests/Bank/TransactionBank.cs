using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank
{
    [TestClass]
    public class TransactionBank
    {
        [TestMethod]
        public void RichRobbingPoorOrTaxes()
        {
            BaseAccount sender = new SavingsAccount(new Guid(), 100);
            BaseAccount recipient = new SavingsAccount(new Guid(), 10000000000);

            Exercite8._1.Bank.Transaction(sender, recipient, 100);

            Assert.AreEqual(10000000100, recipient.SumAccount);
            Assert.AreEqual(0, sender.SumAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TransactionCloseAccount()
        {
            BaseAccount sender = new SavingsAccount(new Guid(), 0);
            BaseAccount recipient = new SavingsAccount(new Guid(), 1000);

            sender.Close();

            Exercite8._1.Bank.Transaction(sender, recipient, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TransactionNegativeSum()
        {
            BaseAccount sender = new SavingsAccount(new Guid(), 1000);
            BaseAccount recipient = new SavingsAccount(new Guid(), 1000);

            Exercite8._1.Bank.Transaction(sender, recipient, -100);
        }
    }
}
