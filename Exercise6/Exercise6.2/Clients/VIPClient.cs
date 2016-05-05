using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise5._2.Clients;
using Exercise6._2;

namespace Exercise6._2.Clients
{
    class VIPClient: BaseClient
    {
        private const int _maxCountAccount = 10;

        public VIPClient() : base(_maxCountAccount) {}

        public VIPClient(Guid number, string name): base (number, name, _maxCountAccount) { }
    }
}
