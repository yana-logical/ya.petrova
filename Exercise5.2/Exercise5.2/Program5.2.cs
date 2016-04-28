using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5._2
{
    /*Реализовать классы для управления банковскими счетами.
    Каждый счет должен иметь номер, владельца, текущую сумму на счету не меньше нуля. Типы счетов:
        сберегательный - возможность пополнения и изъятия денег со счета
        накопительный - возможность пополнения и изъятия денег со счета, но не меньше первоначального взноса, наличие процентной ставки, капитализация процентов за месяц
        расчетный - возможность пополнения и изъятия денег со счета, наличие платы за обслуживание, списание суммы за обслуживание со счета
        обезличенный металлический счет - тип металла, количество грамм, стоимость за грамм (текущий курс), возможность пополнять и обналичивать счет по текущему курсу
    Реализовать метод закрытия счета. С закрытым счетом нельзя проводить никакие операции. Счет не может быть закрыт, если он имеет положительный баланс.*/
    class Program
    {
        public static int GetInt()
        {
            int value;
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            else
            {
                return 0;
            }

        }

        public static double GetDouble()
        {
            double value;
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        public static double GetPositiveDouble()
        {
            double value;
            if (double.TryParse(Console.ReadLine(), out value))
            {
                if (value >= 0)
                {
                    return value;
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public static int lastMonth()
        {
            return (DateTime.Now.Month - 1 == 0) ? 12 : (DateTime.Now.Month - 1);
        }

        public static int yearLastMonth()
        {
            return (lastMonth() == 12) ? (DateTime.Now.Year - 1) : DateTime.Now.Year;
        }

        static void Main(string[] args)
        {
        }
    }
}
