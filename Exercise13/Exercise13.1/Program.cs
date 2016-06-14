using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercise13._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество дробей");

            int count = Operation.GetPositiveInt();
            var random = new Random();
            var listFraction = new List<Fraction>(count);

            for (int i = 0; i < count; i++)
            {
                listFraction.Add(new Fraction(random.Next(20), random.Next(20) + 1));
            }

            try
            {
                SaveXmlToFile(listFraction);
                Console.WriteLine("XML-файл сформирован");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //try
            //{
                //SaveBinaryToFile(listFraction);
                //Console.WriteLine("Binary-файл сформирован");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            Console.WriteLine("Исходный список дробей");
            foreach (var f in listFraction)
            {
                Console.WriteLine(f);
            }

            var listFractionFromXml = LoadFromXmlFile();
            Console.WriteLine("Список дробей из XML-файла");
            foreach (var f in listFractionFromXml)
            {
                Console.WriteLine(f);
            }

            //var listFractionFromBinary = LoadFromBinaryFile();
            //Console.WriteLine("Список дробей из XML-файла");
            //foreach (var f in listFractionFromBinary)
            //{
            //    Console.WriteLine(f);
            //}


            Console.ReadKey();

        }

        public static void SaveXmlToFile(List<Fraction> fraction)
        {
            var writer = new XmlSerializer(typeof(List<Fraction>));
            using (var sw = new StreamWriter(@"E:\fraction.xml"))
            {
                writer.Serialize(sw,fraction);
            }
        }

        //public static void SaveBinaryToFile(List<Fraction> fractions)
        //{
        //    using (var fs = new FileStream(@"E:\fraction.dat", FileMode.Create))
        //    {
        //        var formatted = new BinaryFormatter();
        //        formatted.Serialize(fs, formatted);
        //    }
        //}
            //Я идиот, но он выдает мне такую ошибку: Additional information:
            //Тип "System.Runtime.Serialization.Formatters.Binary.BinaryFormatter"
            //в сборке "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" не помечен как сериализуемый.

        public static List<Fraction> LoadFromXmlFile()
        {
            var writer = new XmlSerializer(typeof(List<Fraction>));
            using (var fs = new FileStream(@"E:\fraction.xml", FileMode.Open))
            {
                return (List<Fraction>)writer.Deserialize(fs);
            }
        }

        //public static List<Fraction> LoadFromBinaryFile()
        //{
        //    var formatted = new BinaryFormatter();
        //    using (var fs = new FileStream(@"E:\fraction.dat", FileMode.Open))
        //    {
        //        return (List<Fraction>)formatted.Deserialize(fs);
        //    }
        //}
    }
}
