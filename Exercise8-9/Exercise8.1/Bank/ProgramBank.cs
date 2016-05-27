using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercite8._1;

namespace Exercise8._1
{
    public class ProgramBank
    {
        static BaseClient client;

        public static void MainBank()
        {
            string typeClient = Console.ReadLine();
            string typeOperation;

            Console.WriteLine("Введите тип клиента (1 - обычный, 2 - простой)");

            if (typeClient == "1")
            {
                Console.WriteLine("Введите имя клиента");
                client = new NormalClient();
            }
            else if (typeClient == "2")
            {
                Console.WriteLine("Введите имя клиента");
                client = new VIPClient();
            }
            else
            {
                Console.WriteLine("Введен неизвестный тип клиента");
            }

            do
            {
                Console.WriteLine("\r\nВыберите тип операции:\r\n" +
                          "1 - добавить счет,\r\n" +
                          "2 - закрыть счет,\r\n" +
                          "3 - посмотреть остаток на всех счетах,\r\n" +
                          "4 - посмотреть остаток по счету,\r\n" +
                          "5 - посмотреть список счетов,\r\n" +
                          "6 - перевести деньги со счета на счет,\r\n" +
                          "0 - прервать программу.");
                typeOperation = Console.ReadLine();

                if (typeOperation == "1")
                {
                    Console.WriteLine("\r\nВведите тип счета:\r\n" +
                                      "1 - накопительный,\r\n" +
                                      "2 - расчетный,\r\n" +
                                      "3 - обезличенный металлический,\r\n" +
                                      "4 - сберегательный.\r\n");
                    string typeAccount = Console.ReadLine();

                    if (typeAccount == "1")
                    {
                        Console.WriteLine("Введите сумму на счету, размеры первоначального взноса и процентной ставки");

                        try
                        {
                            client.CreateAccumulationAccount();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    else if (typeAccount == "2")
                    {
                        Console.WriteLine("Введите сумму на счету, размер платы за обслуживание");

                        try
                        {
                            client.CreateCheckingAccount();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    else if (typeAccount == "3")
                    {
                        Console.WriteLine("Введите сумму на счету, тип металла");

                        try
                        {
                            client.CreateMetalAccount();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    else if (typeAccount == "4")
                    {
                        Console.WriteLine("Введите сумму на счету");

                        try
                        {
                            client.CreateSavingsAccount();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                }
                if (typeOperation == "2")
                {
                    Guid number = Guid.Parse(Console.ReadLine());
                    try
                    {
                        client.CloseAccount(number);
                        Console.WriteLine("Счет #" + number + "закрыт.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (typeOperation == "3")
                {
                    try
                    {
                        Console.WriteLine("Общая сумма на счетах = " + client.GetSumAllAccount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (typeOperation == "4")
                {
                    Guid number = Guid.Parse(Console.ReadLine());
                    try
                    {
                        Console.WriteLine("Сумма на счете #" + number + " равна " + client.GetSumAccount(number));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (typeOperation == "5")
                {
                    try
                    {
                        Console.WriteLine("Номера счетов клиента:\r\n");
                        List<BaseAccount> allAccounts = client.GetAllAccount();

                        for (int i = 0; i < allAccounts.Count; i++)
                        {
                            Console.WriteLine(allAccounts[i].Number);
                        }
                        client.GetAllAccount();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (typeOperation == "6")
                {
                    Console.WriteLine("Введите номер счета отправителя, получателя и сумму через Enter");
                    Guid senderGuid = Guid.Parse(Console.ReadLine());
                    Guid recipientGuid = Guid.Parse(Console.ReadLine());
                    double sum = Operation.GetPositiveDouble();
                    List<BaseAccount> allAccounts = client.GetAllAccount();
                    BaseAccount sender = null;
                    BaseAccount recipient = null;

                    foreach (BaseAccount t in allAccounts)
                    {
                        if (senderGuid == t.Number)
                        {
                            sender = t;
                        }
                        if (recipientGuid == t.Number)
                        {
                            recipient = t;
                        }
                    }

                    try
                    {
                        Bank.Transaction(sender, recipient, sum);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (typeOperation == "0")
                {
                    break;
                }

            } while (typeOperation == "0");

            Console.ReadKey();
        }
    }
}
