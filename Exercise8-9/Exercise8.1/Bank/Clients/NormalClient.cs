using System;

namespace Exercite8._1
{
    public class NormalClient: BaseClient
    {
        private const int _maxCountAccount = 3;

        public NormalClient() : base(_maxCountAccount) { }

        public NormalClient(Guid number, string name): base (number, name, _maxCountAccount) { }

    }
}
