using System;

namespace Exercite8._1
{
    //обезличенный металлический счет
    public class MetalAccount: BaseAccount
    {
        private string _metalType;
        private double _costGram;
        private double _amountGrams;

        public MetalAccount(Guid number, double sumAccount, string metalType, double costGram) : base(number, sumAccount)
        {
            _metalType = metalType;
            _costGram = costGram;
            _amountGrams = sumAccount / costGram;
        }

        public MetalAccount()
        {
            _metalType = Console.ReadLine();
            _costGram = Operation.GetPositiveDouble();
            _amountGrams = SumAccount / CostGram;
        }

        public string MetalType
        {
            get { return _metalType; }
            private set
            {
                if (!IsActiveAccount)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                    throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
                }
                MetalType = value;
            }
        }

        public double CostGram
        {
            get { return _costGram; }
            private set
            {
                if (!IsActiveAccount)
                {
                    Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                    throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
                }
                _costGram = value;
            }
        }

        public double AmountGrams
        {
            get { return _amountGrams; }
        }

        public override void Refill(double value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (value <= 0)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Сумма пополнения меньше или равна 0" + value);
                throw new ArgumentOutOfRangeException("Сумма пополнения меньше или равна 0" + value);
            }
            SumAccount = SumAccount + value;
            _amountGrams = _amountGrams + value / CostGram;
        }


        public override void Withdrawals(double value)
        {
            if (value <= 0)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Сумма пополнения меньше или равна 0" + value);
                throw new ArgumentOutOfRangeException("Сумма пополнения меньше или равна 0" + value);
            }
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            if (value >= SumAccount)
            {
                throw new ArgumentOutOfRangeException("Сумма списания меньше оставшейся суммы на счете: " + value);
            }
            SumAccount = SumAccount - value;
            _amountGrams = _amountGrams - value / CostGram;
        }
    }
}
