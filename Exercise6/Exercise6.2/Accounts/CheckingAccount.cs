using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._2
{
    //расчетный
    public class CheckingAccount: BaseAccount
    {
        public CheckingAccount(Guid number, double sumAccount, bool isActiveAccount,
                                double accountMaintenance) : base(number, sumAccount, isActiveAccount)
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
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
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
                    Bank.AddLogs("|" + GetType().Name + "| " + "На счете недостаточно средств для списания платы за обслуживание. Текущий баланс: " + SumAccount + ", размер платы: " + AccountMaintenance);
                    return false;
                }
            }
            else
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                return false;
            }
        }
    }
}
