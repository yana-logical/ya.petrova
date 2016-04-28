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
        string _number;
        string _owner;
        double _sumAccount;
        string _status;

        public SavingsAccount(string number, string owner, double sumAccount, string status)
        {
            Number = number;
            Owner = owner;
            SumAccount = sumAccount;
            Status = status;
        }

        public SavingsAccount()
        {
            Number = Console.ReadLine();
            Owner = Console.ReadLine();
            SumAccount = Program.GetPositiveDouble();
            Status = "open";

        }

        public string Number
        {
            get { return _number; }
            set
            {
                if (GetStateAccount())
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
                if (GetStateAccount())
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
                if (GetStateAccount())
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
                if (GetStateAccount())
                {
                    _status = value;
                }
            }
        }

        public virtual void Refill(double value)
        {
            if (GetStateAccount())
            {
                SumAccount = SumAccount + value;
            }
        }

        public virtual void Withdrawals(double value)
        {
            if (GetStateAccount())
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
        }

        public void Close()
        {
            if (SumAccount == 0)
            {
                Status = "closed";
            }
            else
            {
                 Console.WriteLine("Невозможно закрыть счет, т.к. его баланс положительный, Остаток на счете: {1}", SumAccount);
            }
        }

        public bool GetStateAccount()
        {
            if (Status == "open")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Операция невозможна. Счет закрыт");
                return false;
            }
        }
    }
}
