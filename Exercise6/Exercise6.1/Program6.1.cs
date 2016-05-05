using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._1
{
     /*Сделать класс Клиент, который может содержать множество счетов (можно взять те, что в ДЗ).
        Сделать свойство, отображающее общую сумму денег на всех счетах.
        Добавить 2 разных счета.*/
    class Program
    {
        static void Main(string[] args)
        {
            Client _client = new Client();

            Console.WriteLine("Введите имя владельца, сумму");
            SavingsAccount _savingsAccount = new SavingsAccount();
            _client.AddAccount(_savingsAccount);

            Console.WriteLine("Введите имя владельца, сумму, стоимость платы за обслуживание");
            CheckingAccount _checkingAccount = new CheckingAccount();
            _client.AddAccount(_checkingAccount);

            double _sumAllAcount = _client.SumAllAccount;

            Console.WriteLine(_sumAllAcount);
            Console.ReadKey();
        }
    }
}
