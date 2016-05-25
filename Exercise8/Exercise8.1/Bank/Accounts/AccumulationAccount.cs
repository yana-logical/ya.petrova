using System;

namespace Exercite8._1
{
    //накопительный
    public class AccumulationAccount: BaseAccount
    {
        public AccumulationAccount(Guid number, double sumAccount, bool isActiveAccount,
                                    double initialFee, double interestRate) : base(number, sumAccount, isActiveAccount)
        {
            InitialFee = initialFee;
            InterestRate = interestRate;
        }

        public AccumulationAccount()
        {
            InitialFee = Operation.GetPositiveDouble();
            InterestRate = Operation.GetPositiveDouble();
        }

        public double InitialFee { get; private set; }

        public void EditInitialFee(double value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            InitialFee = value;
        }

        public double InterestRate { get; private set; }

        public void EditInterestRate(double value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            InterestRate = value;
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
                throw new ArgumentOutOfRangeException("Сумма списания меньше оставшейся суммы на счете: " + value);
            }
            if (SumAccount - value >= InitialFee)
            {
                throw new ArgumentOutOfRangeException("Изъятие средств в размере " + value + " невозможно, т.к.после него сумма на счете будет меньше первоначального взноса");
            }
            EditSumAccount(SumAccount - value);
        }

        public void InterestCapitalization()
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (DateTime.Now.Day == 1)
            {
                int countDayInYear = DateTime.IsLeapYear(Operation.GetYearOfPreviousMonth()) ? 366 : 365;
                int countDayInMonth = DateTime.DaysInMonth(Operation.GetYearOfPreviousMonth(), Operation.GetPreviousMonth());
                EditSumAccount(SumAccount + SumAccount * InitialFee * countDayInMonth / (countDayInYear * 100));
            }
        }
    }
}
