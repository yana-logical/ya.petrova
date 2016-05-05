using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._2
{
    //сберегательный
    public class SavingsAccount: BaseAccount
    {
        public SavingsAccount(Guid number, double sumAccount, bool isActiveAccount) : base(number, sumAccount, isActiveAccount)
        {
        }

        public SavingsAccount()
        {
        }
    }
}
