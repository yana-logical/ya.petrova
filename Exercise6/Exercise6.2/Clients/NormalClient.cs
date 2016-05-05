using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise5._2.Clients;

namespace Exercise6._2.Clients
{
    class NormalClient: BaseClient
    {
        private const int _maxCountAccount = 3;

        public NormalClient() : base(_maxCountAccount) { }

        public NormalClient(Guid number, string name): base (number, name, _maxCountAccount) { }

    }
}
