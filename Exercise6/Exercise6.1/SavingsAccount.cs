using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._1
{
    //сберегательный
    public class SavingsAccount: BankAccount
    {
        public SavingsAccount(Guid number, string owner, double sumAccount, bool isActiveAccount) : base(number, owner, sumAccount, isActiveAccount)
        {
        }

        public SavingsAccount()
        {
        }
    }
}
