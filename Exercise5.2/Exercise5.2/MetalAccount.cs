using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5._2
{
    //обезличенный металлический счет
    public class MetalAccount: SavingsAccount
    {
        string _metalType;
        double _amountGrams;
        double _costGram;
        public MetalAccount(Guid number, string owner, double sumAccount, bool isActiveAccount,
                                   string metalType, double amountGrams, double costGram) : base(number, owner, sumAccount, isActiveAccount)
        {
            _metalType = metalType;
            _amountGrams = amountGrams;
            _costGram = costGram;
        }

        public MetalAccount()
        {
            _metalType = Console.ReadLine();
            _amountGrams = GetPositiveDouble();
            _costGram = GetPositiveDouble();
        }

        public string GetMetalType()
        {
            return _metalType;
        }

        public bool EditMetalType (string value)
        {
            if (GetIsActiveAccount())
            {
                _metalType = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public double GetAmountGrams()
        {
            return _amountGrams;
        }

        public bool EditAmountGrams(double value)
        {
            if (GetIsActiveAccount())
            {
                _amountGrams = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public double GetCostGram()
        {
            return _costGram;
        }

        public bool EditCostGram(double value)
        {
            if (GetIsActiveAccount())
            {
                _costGram = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public override bool Refill(double value)
        {
            if (GetIsActiveAccount())
            {
                EditSumAccount(GetSumAccount() + value);
                _amountGrams = _amountGrams + value / _costGram;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }


        public override bool Withdrawals(double value)
        {
            if (GetIsActiveAccount())
            {
                if (value <= GetSumAccount())
                {
                    EditSumAccount(GetSumAccount() - value);
                    _amountGrams = _amountGrams - value / _costGram;
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
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
    }
    }
}
