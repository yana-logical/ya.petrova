using System;
using Exercite8._1;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Client
{
    [TestClass]
    public class RenameClient
    {
        [TestMethod]
        public void NormalRenameClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");

            client.Name = "Человек";

            Assert.AreEqual("Человек", client.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NullRenameClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");

            client.Name = "";
        }
    }
}
