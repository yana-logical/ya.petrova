using System;

namespace Exercise7._1.Clients
{
    class VIPClient: BaseClient
    {
        private const int _maxCountAccount = 10;

        public VIPClient() : base(_maxCountAccount) {}

        public VIPClient(Guid number, string name): base (number, name, _maxCountAccount) { }
    }
}
