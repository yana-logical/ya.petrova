using System;

namespace Exercite8._1
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
            AccountMaintenance = Operation.GetPositiveDouble();
        }

        public double AccountMaintenance { get; private set; }

        public void EditAccountMaintenance(double value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            AccountMaintenance = value;
        }

        public void CancellationFeesForAccountMaintenance()
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (SumAccount < AccountMaintenance)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "На счете недостаточно средств для списания платы за обслуживание. Текущий баланс: " + SumAccount + ", размер платы: " + AccountMaintenance);
                throw new ArgumentOutOfRangeException("На счете недостаточно средств для списания платы за обслуживание. Текущий баланс: " + SumAccount + ", размер платы: " + AccountMaintenance);
            }
            if (DateTime.Now.Day == 1)
            {
                EditSumAccount(SumAccount-AccountMaintenance);
            }
        }
    }
}
