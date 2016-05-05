using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise6._2;

namespace Exercise6._2
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
            InitialFee = GetPositiveDouble();
            InterestRate = GetPositiveDouble();
        }

        public double InitialFee { get; private set; }

        public bool EditInitialFee(double value)
        {
            if (IsActiveAccount)
            {
                InitialFee = value;
                return true;
            }
            else
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public double InterestRate { get; private set; }

        public bool EditInterestRate(double value)
        {
            if (IsActiveAccount)
            {
                InterestRate = value;
                return true;
            }
            else
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public override bool Withdrawals(double value)
        {
            if (IsActiveAccount)
            {
                if (SumAccount- value >= InitialFee)
                {
                    if (value <= SumAccount)
                    {
                        EditSumAccount(SumAccount - value);
                        return true;
                    }
                    else
                    {
                        Bank.AddLogs("|" + GetType().Name + "| " + "Сумма изъятия " + value + " больше остатка на счете " + SumAccount);
                        return false;
                    }
                }
                else
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Изъятие средств в размере " + value + " невозможно, т.к. после него сумма на счете будет меньше первоначального взноса " + InitialFee + ". Текущий баланс: " + SumAccount);
                    return false;
                }
            }
            else
            {
                Bank.AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public bool InterestCapitalization()
        {
            if (IsActiveAccount)
            {
                if (DateTime.Now.Day == 1)
                {

                    int countDayInYear = DateTime.IsLeapYear(GetYearOfPreviousMonth()) ? 366 : 365;
                    int countDayInMonth = DateTime.DaysInMonth(GetYearOfPreviousMonth(), GetPreviousMonth());
                    EditSumAccount(SumAccount + SumAccount * InitialFee * countDayInMonth / (countDayInYear * 100));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Bank.AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }
    }
}
