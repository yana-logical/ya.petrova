using System;

namespace Exercite8._1
{
    //накопительный
    public class AccumulationAccount: BaseAccount
    {
        private double _initialFee;
        private double _interestRate;

        public AccumulationAccount(Guid number, double sumAccount, double initialFee, double interestRate) : base(number, sumAccount)
        {
            _initialFee = initialFee;
            _interestRate = interestRate;
        }

        public AccumulationAccount()
        {
            _initialFee = Operation.GetPositiveDouble();
            _interestRate = Operation.GetPositiveDouble();
        }

        public double InitialFee
        {
            get { return _initialFee; }
            private set
            {
                if (!IsActiveAccount)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                    throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
                }
                _initialFee = value;
            }
        }

        public double InterestRate
        {
            get { return _interestRate; }
            private set
            {
                if (!IsActiveAccount)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                    throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
                }
                _interestRate = value;
            }
        }

        public override void Withdrawals(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Сумма пополнения меньше или равна 0" + value);
            }
            if (!IsActiveAccount)
            {
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (value >= SumAccount)
            {
                throw new ArgumentOutOfRangeException("Сумма списания больше оставшейся суммы на счете: " + value);
            }
            if (SumAccount - value >= InitialFee)
            {
                throw new ArgumentOutOfRangeException("Изъятие средств в размере " + value + " невозможно, т.к.после него сумма на счете будет меньше первоначального взноса");
            }
            SumAccount  = SumAccount - value;
        }

        public void InterestCapitalization()
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (NowDate.Day == 1)
            {
                int countDayInYear = DateTime.IsLeapYear(Operation.GetYearOfPreviousMonth(NowDate)) ? 366 : 365;
                int countDayInMonth = DateTime.DaysInMonth(Operation.GetYearOfPreviousMonth(NowDate), Operation.GetPreviousMonth(NowDate));
                SumAccount = SumAccount + SumAccount * InitialFee * countDayInMonth / (countDayInYear * 100);
            }
        }

        protected virtual DateTime NowDate
        {
            get { return DateTime.Now; }
        }
    }
}
