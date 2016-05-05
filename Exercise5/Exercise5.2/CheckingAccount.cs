using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5._2
{
    //расчетный
    public class CheckingAccount: SavingsAccount
    {
        public CheckingAccount(Guid number, string owner, double sumAccount, bool isActiveAccount,
                                double accountMaintenance) : base(number, owner, sumAccount, isActiveAccount)
        {
            AccountMaintenance = accountMaintenance;
        }

        public CheckingAccount()
        {
            AccountMaintenance = GetPositiveDouble();
        }

        public double AccountMaintenance { get; private set; }

        public bool EditAccountMaintenance(double value)
        {
            if (IsActiveAccount)
            {
                AccountMaintenance = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public bool CancellationFeesForAccountMaintenance()
        {
            if (IsActiveAccount)
            {
                if (SumAccount > AccountMaintenance)
                {
                    if (DateTime.Now.Day == 1)
                    {
                        EditSumAccount(SumAccount-AccountMaintenance);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    AddLogs("На счете недостаточно средств для списания платы за обслуживание. Текущий баланс: " + SumAccount + ", размер платы: " + AccountMaintenance);
                    return false;
                }
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }
    }
}
