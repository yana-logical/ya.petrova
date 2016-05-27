using System;

namespace Exercite8._1
{
    //базовый
    public abstract class BaseAccount
    {
        private double _sumAccount;

        public BaseAccount(Guid number, double sumAccount)
        {
            IsActiveAccount = true;
            Number = number;
            SumAccount = sumAccount;
        }

        public BaseAccount()
        {
            IsActiveAccount = true;
            Number = Guid.NewGuid();
            SumAccount = Operation.GetPositiveDouble();
        }

        public Guid Number { get; private set; }

        public double SumAccount
        {
            get { return _sumAccount; }
            protected set
            {
                if (!IsActiveAccount)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                    throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
                }
                if (value < 0)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Сумма на счету не может быть меньше нуля.");
                    throw new InvalidOperationException("Сумма на счету не может быть меньше нуля.");
                }
                _sumAccount = value;
            }
        }

        public bool IsActiveAccount { get; protected set; }

        public virtual void Refill(double value)
        {
            if (!IsActiveAccount)
            {
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Сумма пополнения меньше или равна 0" + value);
            }
            SumAccount = SumAccount + value;
        }

        public virtual void Withdrawals(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Сумма пополнения меньше или равна 0" + value);
            }
            if (!IsActiveAccount)
            {
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (value > SumAccount)
            {
                throw new ArgumentOutOfRangeException("Сумма списания меньше оставшейся суммы на счете: " + value);
            }
            SumAccount = SumAccount - value;
        }

        public void Close()
        {
            if (Math.Abs(SumAccount) > double.Epsilon)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Невозможно закрыть счет, т.к. его баланс положительный. Остаток на счете: " + SumAccount);
                throw new InvalidOperationException("Невозможно закрыть счет, т.к. его баланс положительный. Остаток на счете: " + SumAccount);
            }
            IsActiveAccount = false;
        }

       
    }
}
