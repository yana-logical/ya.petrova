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
        public MetalAccount(string number, string owner, double sumAccount, string status,
                                   string metalType, double amountGrams, double costGram) : base(number, owner, sumAccount, status)
        {
            MetalType = metalType;
            AmountGrams = amountGrams;
            CostGram = costGram;
        }

        public MetalAccount()
        {
            MetalType = Console.ReadLine();
            AmountGrams = Program.GetPositiveDouble();
            CostGram = Program.GetPositiveDouble();
        }

        public string MetalType
        {
            get { return _metalType; }
            set
            {
                if (GetStateAccount())
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
                if (GetStateAccount())
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
                if (GetStateAccount())
                {
                    _costGram = value;
                }
            }
        }

        public override void Refill(double value)
        {
            if (GetStateAccount())
            {
                SumAccount = SumAccount + value;
                AmountGrams = AmountGrams + value / CostGram;
            }
        }


        public override void Withdrawals(double value)
        {
            if (GetStateAccount())
            {
                if (value <= SumAccount)
                {
                    SumAccount = SumAccount - value;
                    AmountGrams = AmountGrams - value / CostGram;
                }
                else
                {
                    Console.WriteLine("Сумма изъятия больше остатка на счете");
                }
            }
    }
    }
}
