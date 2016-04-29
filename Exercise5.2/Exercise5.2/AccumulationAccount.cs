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
                    }
                    else
                    {
                        Console.WriteLine("Сумма изъятия {1} больше остатка на счете {2}", value, SumAccount);
                    }
                }
                else
                {
                    Console.WriteLine("Изъятие средств в размере {1} невозможно, т.к. после него сумма на счете будет меньше первоначального взноса {2}. Текущий баланс: {3}",
                                    value, InitialFee, SumAccount);
                }
            }
        }

        public void InterestCapitalization()
        {
            if (IsActiveAccount())
            {
                if (DateTime.Now.Day == 1)
                {

                    int countDayInYear = DateTime.IsLeapYear(YearLastMonth()) ? 366 : 365;
                    int countDayInMonth = DateTime.DaysInMonth(YearLastMonth(), LastMonth());
                    SumAccount = SumAccount + SumAccount * InitialFee * countDayInMonth / (countDayInYear * 100);
                }
            }
        }


    }
}
