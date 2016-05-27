using System;
using System.Collections.Generic;

namespace Exercite8._1
{
    public class Bank
    {
        private static List<string> _logs = new List<string>();

        public static void AddLogs(string value)
        {
            _logs.Add(Convert.ToString("[" + DateTime.Now + "] " + value));
        }

        public List<string> GetLogs()
        {
            return _logs;
        }

        public static void Transaction(BaseAccount sender, BaseAccount recipient, double sum)
        {
            try
            {
                sender.Withdrawals(sum);
                recipient.Refill(sum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
