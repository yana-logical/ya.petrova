using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class LegalEntity: Client
    {

        public LegalEntity(Guid id, string phone, double sumOrder,
                            string nameLegalEntity, string numberAccount) : base(id, phone, sumOrder)
        {
            NameLegalEntity = nameLegalEntity;
            NumberAccount = numberAccount;
        }

        public LegalEntity()
        {
            NameLegalEntity = Console.ReadLine();
            NumberAccount = Console.ReadLine();
        }

        public string NameLegalEntity { get; set; }

        public string NumberAccount { get; set; }

    }
}
