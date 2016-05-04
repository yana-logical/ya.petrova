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

        public AccumulationAccount(Guid number, string owner, double sumAccount, bool isActiveAccount,
                                    double initialFee, double interestRate) : base(number, owner, sumAccount, isActiveAccount)
        {
            _initialFee = initialFee;
            _interestRate = interestRate;
        }

        public AccumulationAccount()
        {
            _initialFee = GetPositiveDouble();
            _interestRate = GetPositiveDouble();
        }

        public double GetInitialFee()
        {
            return _initialFee;
        }

        public bool EditInitialFee(double value)
        {
            if (GetIsActiveAccount())
            {
                _initialFee = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetInterestRate()
        {
            return _interestRate;
        }

        public bool EditInterestRate(double value)
        {
            if (GetIsActiveAccount())
            {
                _interestRate = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Withdrawals(double value)
        {
            if (GetIsActiveAccount())
            {
                if (GetSumAccount() - value >= GetInitialFee())
                {
                    if (value <= GetSumAccount())
                    {
                        EditSumAccount(GetSumAccount() - value);
                        return true;
                    }
                    else
                    {
                        AddLogs("Сумма изъятия " + value + " больше остатка на счете " + GetSumAccount());
                        return false;
                    }
                }
                else
                {
                    AddLogs("Изъятие средств в размере " + value + " невозможно, т.к. после него сумма на счете будет меньше первоначального взноса " + GetInitialFee() + ". Текущий баланс: " + GetSumAccount());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool InterestCapitalization()
        {
            if (GetIsActiveAccount())
            {
                if (DateTime.Now.Day == 1)
                {

                    int countDayInYear = DateTime.IsLeapYear(GetYearOfPreviousMonth()) ? 366 : 365;
                    int countDayInMonth = DateTime.DaysInMonth(GetYearOfPreviousMonth(), GetPreviousMonth());
                    EditSumAccount(GetSumAccount() + GetSumAccount() * GetInitialFee() * countDayInMonth / (countDayInYear * 100));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
