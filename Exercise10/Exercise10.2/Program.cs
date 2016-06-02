using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Exercise10._2
{
    /*Считать из файла flowCards.Card все контакты, сохранить в 2 разных файла: рекламные и не рекламные контакты (разделять по атрибуту IsPromotional).
    Формат файла:
        <Contact_Value> [<Description>]*/
    class Program
    {
        static void Main(string[] args)
        {
            bool contactExistence = false;
            XmlDocument card = new XmlDocument();
            card.Load(@"C:\Users\ya.petrova\Downloads\flowCards.Card.xml");
            XmlElement cardRoot = card.DocumentElement;

            using (StreamWriter promotionalContact = new StreamWriter(@"E:\PromotionalContact.txt"))
            using (StreamWriter noPromotionalContact = new StreamWriter(@"E:\NoPromotionalContact.txt"))
            {
                foreach (XmlElement cardNode in cardRoot)
                {
                    if (cardNode.Name == "Contacts")
                    {
                        contactExistence = true;

                        foreach (XmlElement contactNode in cardNode)
                        {
                            bool isPromotional = false;
                            string value;
                            string description = "нет описания";

                            if (contactNode.HasAttribute("IsPromotional"))
                            {
                                isPromotional = Convert.ToBoolean(contactNode.Attributes.GetNamedItem("IsPromotional").Value);
                            }

                            if (contactNode.HasAttribute("Description"))
                            {
                                description = contactNode.Attributes.GetNamedItem("Description").Value;
                            }

                            value = contactNode.Attributes.GetNamedItem("Value").Value;

                            if (isPromotional)
                            {
                                promotionalContact.WriteLine(value + "[" + description + "]");
                            }
                            else
                            {
                                noPromotionalContact.WriteLine(value + "[" + description + "]");
                            }
                        }
                    }
                }
                if (!contactExistence)
                {
                    throw new InvalidOperationException("В карточке нет блока контактов");
                }
            }
        }
    }
}
