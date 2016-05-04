using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5._2
{
    //рассчетный
    public class CheckingAccount: SavingsAccount
    {
        double _accountMaintenance;

        public CheckingAccount(Guid number, string owner, double sumAccount, string status,
                                double accountMaintenance) : base(number, owner, sumAccount, status)
        {
            AccountMaintenance = accountMaintenance;
        }

        public CheckingAccount()
        {
            AccountMaintenance = GetPositiveDouble();
        }

        public double AccountMaintenance
        {
            get { return _accountMaintenance; }
            set
            {
                if (IsActiveAccount())
                {
                    _accountMaintenance = value;
                }
            }
        }

        public void CancellationFeesForAccountMaintenance()
        {
            if (IsActiveAccount())
            {
                if (SumAccount > AccountMaintenance)
                {
                    if (DateTime.Now.Day == 1)
                    {
                        SumAccount = SumAccount - AccountMaintenance;
                        SuccessfulOperation = true;
                    }
                }
                else
                {
                    AddLogs("На счете недостаточно средств для списания платы за обслуживание. Текущий баланс: " + SumAccount + ", размер платы: " + AccountMaintenance);
                }
            }
        }
    }
}
