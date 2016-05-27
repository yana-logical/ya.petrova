using System;

namespace Exercite8._1
{
    //расчетный
    public class CheckingAccount: BaseAccount
    {
        private double _accountMaintenance;

        public CheckingAccount(Guid number, double sumAccount, double accountMaintenance) : base(number, sumAccount)
        {
            _accountMaintenance = accountMaintenance;
        }

        public CheckingAccount()
        {
            _accountMaintenance = Operation.GetPositiveDouble();
        }

        public double AccountMaintenance
        {
            get { return _accountMaintenance; }
            private set
            {
                if (!IsActiveAccount)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                    throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
                }
                _accountMaintenance = value;
            }
        }

        public void WriteOffForAccountMaintenance()
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
            if (NowDate.Day == 1)
            {
                SumAccount = SumAccount - AccountMaintenance;
            }
        }

        protected virtual DateTime NowDate
        {
            get { return DateTime.Now; }
        }
    }
}
