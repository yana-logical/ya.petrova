using System;

namespace Exercite8._1
{
    //обезличенный металлический счет
    public class MetalAccount: BaseAccount
    {
        public MetalAccount(Guid number, double sumAccount, bool isActiveAccount,
                                   string metalType, double amountGrams, double costGram) : base(number, sumAccount, isActiveAccount)
        {
            MetalType = metalType;
            AmountGrams = amountGrams;
            CostGram = costGram;
        }

        public MetalAccount()
        {
            MetalType = Console.ReadLine();
            AmountGrams = Operation.GetPositiveDouble();
            CostGram = Operation.GetPositiveDouble();
        }

        public string MetalType { get; private set; }

        public void EditMetalType (string value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            MetalType = value;
        }

        public double AmountGrams { get; private set; }

        public void EditAmountGrams(double value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            AmountGrams = value;
        }

        public double CostGram { get; private set; }

        public void EditCostGram(double value)
        {
            if (!IsActiveAccount)
            {
                Bank.AddLogs("|" + GetType().Name + "| " + "Счет закрыт. Операция невозможна.");
                throw new InvalidOperationException("Операция невозможна. Счет закрыт.");
            }
            CostGram = value;
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
            EditSumAccount(SumAccount + value);
            AmountGrams = AmountGrams + value / CostGram;
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
            EditSumAccount(SumAccount - value);
            AmountGrams = AmountGrams - value / CostGram;
        }
    }
}
