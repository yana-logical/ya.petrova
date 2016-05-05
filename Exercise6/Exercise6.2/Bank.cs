using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6._2
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

        public void Transaction(BaseAccount from, BaseAccount to, double sum)
        {
            from.Withdrawals(sum);
            to.Refill(sum);
        }
    }
}
