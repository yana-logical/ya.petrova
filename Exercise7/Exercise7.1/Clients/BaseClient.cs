using System;
using System.Collections.Generic;
using Exercise7._1.Accounts;

namespace Exercise7._1.Clients
{
    public abstract class BaseClient: IComparable
    {
        private List<BaseAccount> _allAccounts;

        protected BaseClient(Guid number, string name, int maxCountAccount)
        {
            Number = number;
            Name = name;
            MaxCountAccount = maxCountAccount;
            _allAccounts = new List<BaseAccount>();

        }

        protected BaseClient(int maxCountAccount)
        {
            Number = Guid.NewGuid();
            Name = Console.ReadLine();
            MaxCountAccount = maxCountAccount;
            _allAccounts = new List<BaseAccount>();
        }

        public Guid Number { get; private set; }

        public string Name { get; set; }

        public int MaxCountAccount { get; private set; }

        public bool AddAccount(BaseAccount value)
        {
            if (_allAccounts.Count < MaxCountAccount)
            {
                _allAccounts.Add(value);
                return true;
            }
            else
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Невозможно добавить счет. У этого типа клиента количество счетов уже равно максимальному: " + MaxCountAccount);
                return false;
            }
        }

        public bool CreateAccumulationAccount()
        {
            AccumulationAccount accumulationAccount = new AccumulationAccount();
            return AddAccount(accumulationAccount);
        }

        public bool CreateCheckingAccount()
        {
            CheckingAccount checkingAccount = new CheckingAccount();
            return AddAccount(checkingAccount);
        }

        public bool CreateMetalAccount()
        {
            MetalAccount metalAccount = new MetalAccount();
            return AddAccount(metalAccount);
        }

        public bool CreateSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            return AddAccount(savingsAccount);
        }

        public List<BaseAccount> GetAllAccount()
        {
            return _allAccounts;
        }

        public double GetSumAllAccount
        {
            get
            {
                double value = 0;
                for (int i = 0; i < _allAccounts.Count; i++)
                {
                    value = value + _allAccounts[i].SumAccount;
                }
                return value;
            }
        }

        public double GetSumAccount(Guid value)
        {
            foreach (BaseAccount t in _allAccounts)
            {
                if (value == t.Number)
                {
                    return t.SumAccount;
                }
            }
            return 0;
        }

        public bool CloseAccount(Guid value)
        {
            foreach (BaseAccount t in _allAccounts)
            {
                if (value == t.Number)
                {
                    return t.Close();
                }
                else
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет с таким номером не найден.");
                    return false;
                }
            }
            Bank.AddLogs("|" + GetType().Name + "| " + "У клиента нет ни одного открытого счета.");
            return false;
        }

        public int CompareTo(object obj)
        {
            BaseClient client = (BaseClient) obj;
            if (client.GetSumAllAccount > GetSumAllAccount)
            {
                return 1;
            }
            if (client.GetSumAllAccount > GetSumAllAccount)
            {
                return -1;
            }
            return 0;
        }

    }
}
