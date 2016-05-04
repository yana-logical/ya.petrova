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
        public MetalAccount(Guid number, string owner, double sumAccount, string status,
                                   string metalType, double amountGrams, double costGram) : base(number, owner, sumAccount, status)
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

        public string MetalType
        {
            get { return _metalType; }
            set
            {
                if (IsActiveAccount())
                {
                    _metalType = value;
                }
            }
        }

        public double AmountGrams
        {
            get { return _amountGrams; }
            set
            {
                if (IsActiveAccount())
                {
                    _amountGrams = value;
                }
            }
        }

        public double CostGram
        {
            get { return _costGram; }
            set
            {
                if (IsActiveAccount())
                {
                    _costGram = value;
                }
            }
        }

        public override void Refill(double value)
        {
            if (IsActiveAccount())
            {
                SumAccount = SumAccount + value;
                AmountGrams = AmountGrams + value / CostGram;
            }
        }


        public override void Withdrawals(double value)
        {
            if (IsActiveAccount())
            {
                if (value <= SumAccount)
                {
                    SumAccount = SumAccount - value;
                    AmountGrams = AmountGrams - value / CostGram;
                    SuccessfulOperation = true;
                }
                else
                {
                    AddLogs("Сумма изъятия " + value + " больше остатка на счете " + SumAccount);
                }
            }
    }
    }
}
