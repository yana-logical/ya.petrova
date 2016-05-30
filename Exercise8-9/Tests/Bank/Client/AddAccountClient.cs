using System;
using Exercite8._1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Bank.Client
{
    [TestClass]
    public class AddAccountClient
    {
        [TestMethod]
        public void AddNormalAccountClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 2000);
            BaseAccount account3 = new SavingsAccount(Guid.NewGuid(), 3000);

            client.AddAccount(account1);
            client.AddAccount(account2);
            client.AddAccount(account3);

            Assert.AreEqual(3, client.GetAllAccount().Count);
            Assert.AreEqual(6000, client.GetSumAllAccount);
        }

        //Почему-то этот тест падает с ошибкой
        /*Managed Debugging Assistant 'DisconnectedContext' has detected aproblem in 
        'C:\PROGRAM FILES (X86)\MICROSOFT VISUAL STUDIO 14.0\COMMON7\IDE\COMMONEXTENSIONS\MICROSOFT\TESTWINDOW\te.processhost.managed.exe'.
        
        Additional information: Переход к COM-контексту 0x9f8be8 для данного объекта
        RuntimeCallableWrapper завершился следующей ошибкой: Вызванный объект
        был отключен от клиентов. (Исключение из HRESULT: 0x80010108 (RPC_E_DISCONNECTED)).
        Обычно это происходит из-за того, что COM-контекст 0x9f8be8, в котором был создан 
        этот объект RuntimeCallableWrapper, отключен или занят другой операцией.
        Выполняется освобождение интерфейсов из текущего COM-контекста (COM-контекст 0x9f89c0).
        Это может привести к повреждению или потере данных. Для устранения этой проблемы убедитесь
        в том, что все контексты, подразделения и потоки будут существовать и оставаться доступными 
        для перехода к контексту до полного завершения работы приложения с объектами 
        RuntimeCallableWrapper, представляющими находящиеся в них COM-компоненты.*/

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddMoreMaxCountAccountAccountClient()
        {
            BaseClient client = new NormalClient(Guid.NewGuid(), "Владелец");
            BaseAccount account1 = new SavingsAccount(Guid.NewGuid(), 1000);
            BaseAccount account2 = new SavingsAccount(Guid.NewGuid(), 2000);
            BaseAccount account3 = new SavingsAccount(Guid.NewGuid(), 3000);
            BaseAccount account4 = new SavingsAccount(Guid.NewGuid(), 4000);

            client.AddAccount(account1);
            client.AddAccount(account2);
            client.AddAccount(account3);
            client.AddAccount(account4);
        }
    }
}
