using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Collections;
using System.IO;

namespace LabWork14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            // 1) Binary
            BinaryFormatter formater = new BinaryFormatter();
            Car car = new Car("bmv", 60, 8, 1);
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carBin.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, car);
                Console.WriteLine("Serialized binary");
            }
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carBin.dat", FileMode.OpenOrCreate))
            {
                Car car1 = new Car();
                car1 = (Car)formater.Deserialize(fs);
                Console.WriteLine("deserialized: car1.speed = {0}", car1.speed);
            }

            // 1) JSON
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Car));
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carJSON.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Serialized json");
                jsonSer.WriteObject(fs, car);
            }
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carJSON.dat", FileMode.OpenOrCreate))
            {
                Car car3 = new Car();
                car3 = (Car)jsonSer.ReadObject(fs);
                Console.WriteLine("deserialized: car3.speed = {0}", car3.speed);
            }

            // 1) XML
            XmlSerializer xmlSer = new XmlSerializer(typeof(Car));
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carXml.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Serialized xml");
                xmlSer.Serialize(fs, car);
            }
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carXml.dat", FileMode.OpenOrCreate))
            {
                Car car2 = new Car();
                car2 = (Car)xmlSer.Deserialize(fs);
                Console.WriteLine("deserialized: car2.speed = {0}", car2.speed);
            }
            #endregion

            #region 2
            Car[] cars = new Car[] { new Car("bmv", 60, 8, 1), new Car("mers", 60, 8, 2), new Car("bmv", 60, 8, 3) };
            DataContractJsonSerializer jsonArrSer = new DataContractJsonSerializer(typeof(Car[]));
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carArrJSON.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Serialized arr json");
                jsonArrSer.WriteObject(fs, cars);
            }
            using (FileStream fs = new FileStream(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carArrJSON.dat", FileMode.OpenOrCreate))
            {
                Car[] cars1 = (Car[])jsonArrSer.ReadObject(fs);
                Console.WriteLine("deserialized: cars.speed = {0}", cars1[1].speed);
            }
            #endregion

            #region 3
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carXml.dat");

            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList chieldNodes = xRoot.SelectNodes("*");
            Console.WriteLine("XPath selector \"*\":");
            foreach (XmlNode i in chieldNodes)
                Console.WriteLine("\t{0}", i.OuterXml);
            #endregion

            #region 4
            XDocument xDocument = XDocument.Load(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork14\carXml.dat");
            var linqToXml = xDocument.Descendants("Car").Select(s => (s.Element("brand").Value, s.Element("speed").Value));
            foreach (var i in linqToXml)
                Console.WriteLine("brand: {0}\tspeed: {1}", i.Item1, i.Item2);

            #endregion
        }
    }
}
