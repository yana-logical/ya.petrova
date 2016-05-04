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
        Guid _number;
        string _owner;
        double _sumAccount;
        string _status;
        List<string> _logs = new List<string>(); 

        public SavingsAccount(Guid number, string owner, double sumAccount, string status)
        {
            Number = number;
            Owner = owner;
            SumAccount = sumAccount;
            if (status == "open" || status == "closed")
            {
                Status = status;
            }
            else
            {
                Console.WriteLine("Введено некорректное значение статуса");
            }
            
        }

        public SavingsAccount()
        {
            Number = Guid.NewGuid();
            Owner = Console.ReadLine();
            SumAccount = GetPositiveDouble();
            Status = "open";

        }

        public Guid Number
        {
            get { return _number; }
            set
            {
                if (IsActiveAccount())
                {
                    _number = value;
                }
            }
        }

        public string Owner
        {
            get { return _owner; }
            set
            {
                if (IsActiveAccount())
                {
                    _owner = value;
                }
            }
        }

        public double SumAccount
        {
            get { return _sumAccount; }
            set
            {
                if (IsActiveAccount())
                {
                    _sumAccount = value;
                }
            }
        }

        private string Status
        {
            get { return _status; }
            set
            {
                if (IsActiveAccount())
                {
                    _status = value;
                }
            }
        }

        public void AddLogs(string value)
        {
            _logs.Add(Convert.ToString("[" + DateTime.Now + "] |" + GetType().Name + "| " + value));
        }

        public List<string> GetLogs()
        {
            return _logs;
        }

        public virtual void Refill(double value)
        {
            if (IsActiveAccount())
            {
                SumAccount = SumAccount + value;
            }
        }

        public virtual void Withdrawals(double value)
        {
            if (IsActiveAccount())
            {
                if (value <= SumAccount)
                {
                    SumAccount = SumAccount - value;
                }
                else
                {
                    AddLogs("Сумма изъятия "+ value + " больше остатка на счете " + SumAccount);
                }
            }
        }

        public void Close()
        {
            if (SumAccount == 0)
            {
                Status = "closed";
            }
            else
            {
                AddLogs("Невозможно закрыть счет, т.к. его баланс положительный. Остаток на счете: " + SumAccount);
            }
        }

        public bool IsActiveAccount()
        {
            if (Status == "open")
            {
                return true;
            }
            else
            {
                AddLogs("Операция невозможна. Счет закрыт");
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
