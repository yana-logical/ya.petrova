using System;
using System.Collections.Generic;

namespace Exercite8._1
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

        public void AddAccount(BaseAccount value)
        {
            if (_allAccounts.Count > MaxCountAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Невозможно добавить счет. У этого типа клиента количество счетов уже равно максимальному: " + MaxCountAccount);
                throw new InvalidOperationException("Невозможно добавить счет. У этого типа клиента количество счетов уже равно максимальному: " + MaxCountAccount);
            }
            _allAccounts.Add(value);
        }

        public void CreateAccumulationAccount()
        {
            AccumulationAccount accumulationAccount = new AccumulationAccount();
            AddAccount(accumulationAccount);
        }

        public void CreateCheckingAccount()
        {
            CheckingAccount checkingAccount = new CheckingAccount();
            AddAccount(checkingAccount);
        }

        public void CreateMetalAccount()
        {
            MetalAccount metalAccount = new MetalAccount();
            AddAccount(metalAccount);
        }

        public void CreateSavingsAccount()
        {
            SavingsAccount savingsAccount = new SavingsAccount();
            AddAccount(savingsAccount);
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

        public void CloseAccount(Guid value)
        {
            foreach (BaseAccount t in _allAccounts)
            {
                if (value == t.Number)
                {
                    t.Close();
                }
                else
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет с таким номером не найден.");
                    throw new InvalidOperationException("Счет с таким номером не найден.");
                }
            }
            Bank.AddLogs("|" + GetType().Name + "| " + "У клиента нет ни одного открытого счета.");
            throw new InvalidOperationException("У клиента нет ни одного открытого счета.");
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
