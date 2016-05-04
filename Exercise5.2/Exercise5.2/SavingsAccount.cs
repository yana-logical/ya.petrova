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
        readonly Guid _number;
        string _owner;
        double _sumAccount;
        bool _isActiveAccount;
        private List<string> _logs = new List<string>();

        public SavingsAccount(Guid number, string owner, double sumAccount, bool isActiveAccount)
        {
            _number = number;
            _owner = owner;
            _sumAccount = sumAccount;
            _isActiveAccount = isActiveAccount;
            
        }

        public SavingsAccount()
        {
            _number = Guid.NewGuid();
            _owner = Console.ReadLine();
            _sumAccount = GetPositiveDouble();
            _isActiveAccount = true;

        }

        private Guid GetNumber ()
        {
           return _number;
        }

        public string GetOwner()
        {
            return _owner;
        }

        public bool EditOwner(string value)
        {
            if (GetIsActiveAccount())
            {
                _owner = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetSumAccount()
        {
            return _sumAccount;
        }

        public bool EditSumAccount(double value)
        {
            if (GetIsActiveAccount())
            {
                _sumAccount = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetIsActiveAccount()
        {
            return _isActiveAccount;
        }

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
            if (GetIsActiveAccount())
            {
                EditSumAccount(GetSumAccount() + value);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool Withdrawals(double value)
        {
            if (GetIsActiveAccount())
            {
                if (value <= GetSumAccount())
                {
                    EditSumAccount(GetSumAccount() - value);
                    return true;
                }
                else
                {
                    AddLogs("Сумма изъятия "+ value + " больше остатка на счете " + GetSumAccount());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CloseAccount()
        {
            if (GetSumAccount() == 0)
            {
                _isActiveAccount = false;
                return true;
            }
            else
            {
                AddLogs("Невозможно закрыть счет, т.к. его баланс положительный. Остаток на счете: " + GetSumAccount());
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
