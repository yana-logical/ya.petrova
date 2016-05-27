using System;

namespace Exercite8._1
{
    public class VIPClient: BaseClient
    {
        private const int _maxCountAccount = 10;

        public VIPClient() : base(_maxCountAccount) {}

        public VIPClient(Guid number, string name): base (number, name, _maxCountAccount) { }
    }
}
