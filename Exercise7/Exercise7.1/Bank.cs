using System;
using System.Collections.Generic;
using Exercise7._1.Accounts;

namespace Exercise7._1
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

        public void Transaction(BaseAccount sender, BaseAccount recipient, double sum)
        {
            sender.Withdrawals(sum);
            recipient.Refill(sum);
        }
    }
}
