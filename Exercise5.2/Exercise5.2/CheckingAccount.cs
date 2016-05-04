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

        public CheckingAccount(Guid number, string owner, double sumAccount, bool isActiveAccount,
                                double accountMaintenance) : base(number, owner, sumAccount, isActiveAccount)
        {
            _accountMaintenance = accountMaintenance;
        }

        public CheckingAccount()
        {
            _accountMaintenance = GetPositiveDouble();
        }

        public double GetAccountMaintenance()
        {
            return _accountMaintenance;
        }

        public bool EditAccountMaintenance(double value)
        {
            if (GetIsActiveAccount())
            {
                _accountMaintenance = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CancellationFeesForAccountMaintenance()
        {
            if (GetIsActiveAccount())
            {
                if (GetSumAccount() > GetAccountMaintenance())
                {
                    if (DateTime.Now.Day == 1)
                    {
                        EditSumAccount(GetSumAccount()-GetAccountMaintenance());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    AddLogs("На счете недостаточно средств для списания платы за обслуживание. Текущий баланс: " + GetSumAccount() + ", размер платы: " + GetAccountMaintenance());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
