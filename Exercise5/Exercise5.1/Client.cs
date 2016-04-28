using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class  Client
    {

        public Client(Guid id, string phone, double sumOrder)
        {
            Id = id;
            Phone = phone;
            SumOrder = sumOrder;
        }

        public Client()
        {
            Id = Guid.NewGuid(); 
            Phone = Console.ReadLine();
            SumOrder = Program.GetDouble();
        }

        public Guid Id { get; set; }

        public string Phone { get; set; }

        public double SumOrder { get; set; }

    }
}
