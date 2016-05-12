using System;

namespace Exercise7._1.Clients
{
    class NormalClient: BaseClient
    {
        private const int _maxCountAccount = 3;

        public NormalClient() : base(_maxCountAccount) { }

        public NormalClient(Guid number, string name): base (number, name, _maxCountAccount) { }

    }
}
