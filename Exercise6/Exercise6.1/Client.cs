using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._1
{
    class Client
    {
        List<BankAccount> _accounts = new List<BankAccount>();
        public Client(Guid number, List<BankAccount> accounts)
        {
            Number = number;
            _accounts = accounts;
        }

        public Client()
        {
            Number = Guid.NewGuid();
        }

        public Guid Number { get; private set; }

        public double SumAllAccount
        {
            get
            {
                double value = 0;
                for (int i = 0; i < _accounts.Count; i++)
                {
                    value = value +_accounts[i].SumAccount;
                }
                return value;
            }
        }

        public bool AddAccount(BankAccount value)
        {
            _accounts.Add(value);
            return true;
        }
    }
}
