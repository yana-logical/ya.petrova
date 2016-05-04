using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5._2
{
    //накопительный
    public class AccumulationAccount: SavingsAccount
    {
        double _initialFee;
        double _interestRate;

        public AccumulationAccount(Guid number, string owner, double sumAccount, string status,
                                    double initialFee, double interestRate) : base(number, owner, sumAccount,status)
        {
            InitialFee = initialFee;
            InterestRate = interestRate;
        }

        public AccumulationAccount()
        {
            InitialFee = GetPositiveDouble();
            InterestRate = GetPositiveDouble();
        }

        public double InitialFee
        {
            get { return _initialFee; }
            set
            {
                if (IsActiveAccount())
                {
                    _initialFee = value;
                }
            }
        }

        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                if (IsActiveAccount())
                {
                    _interestRate = value;
                }
            }
        }

        public override void Withdrawals(double value)
        {
            if (IsActiveAccount())
            {
                if (SumAccount - value >= InitialFee)
                {
                    if (value <= SumAccount)
                    {
                        SumAccount = SumAccount - value;
                        SuccessfulOperation = true;
                    }
                    else
                    {
                        AddLogs("Сумма изъятия " + value + " больше остатка на счете " + SumAccount);
                    }
                }
                else
                {
                    AddLogs("Изъятие средств в размере " + value + " невозможно, т.к. после него сумма на счете будет меньше первоначального взноса " + InitialFee + ". Текущий баланс: " + SumAccount);
                }
            }
        }

        public void InterestCapitalization()
        {
            if (IsActiveAccount())
            {
                if (DateTime.Now.Day == 1)
                {

                    int countDayInYear = DateTime.IsLeapYear(GetYearOfPreviousMonth()) ? 366 : 365;
                    int countDayInMonth = DateTime.DaysInMonth(GetYearOfPreviousMonth(), GetPreviousMonth());
                    SumAccount = SumAccount + SumAccount * InitialFee * countDayInMonth / (countDayInYear * 100);
                }
            }
        }


    }
}
