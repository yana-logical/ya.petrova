using System;

namespace Exercite8._1
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
