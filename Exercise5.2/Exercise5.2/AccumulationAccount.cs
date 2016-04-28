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
        double _anInitialFee;
        double _interestRate;

        public AccumulationAccount(string number, string owner, double sumAccount, string status,
                                    double anInitialFee, double interestRate) : base(number, owner, sumAccount,status)
        {
            AnInitialFee = anInitialFee;
            InterestRate = interestRate;
        }

        public AccumulationAccount()
        {
            AnInitialFee = Program.GetPositiveDouble();
            InterestRate = Program.GetPositiveDouble();
        }

        public double AnInitialFee
        {
            get { return _anInitialFee; }
            set
            {
                if (GetStateAccount())
                {
                    _anInitialFee = value;
                }
            }
        }

        public double InterestRate
        {
            get { return _interestRate; }
            set
            {
                if (GetStateAccount())
                {
                    _interestRate = value;
                }
            }
        }

        public override void Withdrawals(double value)
        {
            if (GetStateAccount())
            {
                if (value <= AnInitialFee)
                {
                    if (value <= SumAccount)
                    {
                        SumAccount = SumAccount - value;
                    }
                    else
                    {
                        Console.WriteLine("Сумма изъятия больше остатка на счете");
                    }
                }
                else
                {
                    Console.WriteLine("Сумма снятия больше первоначального взноса");
                }
            }
        }

        public void InterestCapitalization()
        {
            if (GetStateAccount())
            {
                if (DateTime.Now.Day == 1)
                {

                    int countDayInYear = DateTime.IsLeapYear(Program.yearLastMonth()) ? 366 : 365;
                    int countDayInMonth = DateTime.DaysInMonth(Program.yearLastMonth(), Program.lastMonth());
                    SumAccount = SumAccount + SumAccount * AnInitialFee * countDayInMonth / (countDayInYear * 100);
                }
            }
        }


    }
}
