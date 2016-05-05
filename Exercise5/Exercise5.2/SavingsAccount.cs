using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5._2
{
    //сберегательный
    public class SavingsAccount
    {
        private List<string> _logs = new List<string>();

        public SavingsAccount(Guid number, string owner, double sumAccount, bool isActiveAccount)
        {
            Number = number;
            Owner = owner;
            SumAccount = sumAccount;
            IsActiveAccount = isActiveAccount;
            
        }

        public SavingsAccount()
        {
            Number = Guid.NewGuid();
            Owner = Console.ReadLine();
            SumAccount = GetPositiveDouble();
            IsActiveAccount = true;

        }

        public Guid Number { get; private set; }

        public string Owner { get; private set; }

        public bool EditOwner(string value)
        {
            if (IsActiveAccount)
            {
                Owner = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        protected double SumAccount { get; set; }

        public bool EditSumAccount(double value)
        {
            if (IsActiveAccount)
            {
                SumAccount = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public bool IsActiveAccount { get; private set; }

        protected void AddLogs(string value)
        {
            _logs.Add(Convert.ToString("[" + DateTime.Now + "] |" + GetType().Name + "| " + value));
        }

        public List<string> GetLogs()
        {
            return _logs;
        }

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
                    AddLogs("Сумма изъятия "+ value + " больше остатка на счете " + SumAccount);
                    return false;
                }
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
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
                AddLogs("Невозможно закрыть счет, т.к. его баланс положительный. Остаток на счете: " + SumAccount);
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
