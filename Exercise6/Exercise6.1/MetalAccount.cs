using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._1
{
    //обезличенный металлический счет
    public class MetalAccount: BankAccount
    {
        public MetalAccount(Guid number, string owner, double sumAccount, bool isActiveAccount,
                                   string metalType, double amountGrams, double costGram) : base(number, owner, sumAccount, isActiveAccount)
        {
            MetalType = metalType;
            AmountGrams = amountGrams;
            CostGram = costGram;
        }

        public MetalAccount()
        {
            MetalType = Console.ReadLine();
            AmountGrams = GetPositiveDouble();
            CostGram = GetPositiveDouble();
        }

        public string MetalType { get; private set; }

        public bool EditMetalType (string value)
        {
            if (IsActiveAccount)
            {
                MetalType = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public double AmountGrams { get; private set; }

        public bool EditAmountGrams(double value)
        {
            if (IsActiveAccount)
            {
                AmountGrams = value;
                return true;
            }
            else
            {
                AddLogs("Счет закрыт. Операция невозможна.");
                return false;
            }
        }

        public double CostGram { get; private set; }

        public bool EditCostGram(double value)
        {
            if (IsActiveAccount)
            {
                CostGram = value;
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
            if (IsActiveAccount)
            {
                EditSumAccount(SumAccount + value);
                AmountGrams = AmountGrams + value / CostGram;
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
            if (IsActiveAccount)
            {
                if (value <= SumAccount)
                {
                    EditSumAccount(SumAccount - value);
                    AmountGrams = AmountGrams - value / CostGram;
                    return true;
                }
                else
                {
                    AddLogs("Сумма изъятия " + value + " больше остатка на счете " + SumAccount);
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
