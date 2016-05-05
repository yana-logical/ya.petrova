using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._2
{
    //базовый
    public abstract class BaseAccount
    {
        public BaseAccount(Guid number, double sumAccount, bool isActiveAccount)
        {
            Number = number;
            SumAccount = sumAccount;
            IsActiveAccount = isActiveAccount;

        }

        public BaseAccount()
        {
            Number = Guid.NewGuid();
            SumAccount = GetPositiveDouble();
            IsActiveAccount = true;

        }

        public Guid Number { get; private set; }

        public double SumAccount { get; protected set; }

        public bool EditSumAccount(double value)
        {
            if (IsActiveAccount)
            {
                SumAccount = value;
                return true;
            }
            else
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public bool IsActiveAccount { get; private set; }

        public virtual bool Refill(double value)
        {
            if (IsActiveAccount)
            {
                EditSumAccount(SumAccount + value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Withdrawals(double value)
        {
            if (IsActiveAccount)
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
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public bool Close()
        {
            if (Math.Abs(SumAccount) < double.Epsilon)
            {
                IsActiveAccount = false;
                return true;
            }
            else
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Невозможно закрыть счет, т.к. его баланс положительный. Остаток на счете: " + SumAccount);
                return false;
            }
        }

        public static double GetPositiveDouble()
        {
            double value;
            if (double.TryParse(Console.ReadLine(), out value))
            {
                if (value >= 0)
                {
                    return value;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public static int GetPreviousMonth()
            //Возращает номер предыдущего месяца
        {
            return (DateTime.Now.Month - 1 == 0) ? 12 : (DateTime.Now.Month - 1);
        }

        public static int GetYearOfPreviousMonth()
            //Возращает номер года предыдущего месяца
        {
            return (GetPreviousMonth() == 12) ? (DateTime.Now.Year - 1) : DateTime.Now.Year;
        }
    }
}
