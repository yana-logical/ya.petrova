using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class SoleProprietor : Client
    {
        public SoleProprietor(Guid id, string phone, double sumOrder,
                                string surname, string name, string patronymic, DateTime dateBirth) : base(id, phone, sumOrder)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateBirth = dateBirth;
        }

        public SoleProprietor()
        {
            Surname = Console.ReadLine();
            Name = Console.ReadLine();
            Patronymic = Console.ReadLine();
            DateBirth = Program.GetDateTime();
        }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateBirth { get; set; }

        public string FormatName()
        {
            string formatName = Surname + " " + Name.First() + ". " + Patronymic.First() + ".";
            return formatName;
        }

    }
}
