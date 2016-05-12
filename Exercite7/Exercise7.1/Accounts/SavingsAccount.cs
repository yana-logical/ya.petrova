using System;

namespace Exercise7._1.Accounts
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
