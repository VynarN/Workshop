using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Serialization;
namespace Workshop
{
    partial class WorkshopMain
    {
        static void Hometask4()
        {
            string DatFile = "cars.dat";
            string XmlFile = "cars.xml";
            string JsonFile = "cars.json";

            List<Car> cars = new List<Car>(){
            new Car()
            {
                carId = 1,
                quantity = 10,
                price = 50000.0m,
                total = 500000.0m
            },
            new Car()
            {
                carId = 2,
                quantity = 5,
                price = 30000.0m,
                total = 150000.0m
            },
            new Car()
            {
                carId = 3,
                quantity = 1,
                price = 40000.0m,
                total = 40000.0m
            }
            };
            #region BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.Open(DatFile, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, cars);
                Console.WriteLine("List of cars was serialized using BinaryFormatter! Check cars.dat file.");
            }
            using (FileStream fs = new FileStream(DatFile, FileMode.Open))
            {
                var newList = (List<Car>)formatter.Deserialize(fs);
                DisplayDeserializedObject(newList);
            }
            #endregion
            #region XmlSerializer
            XmlSerializer xs = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = File.Open(XmlFile, FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, cars);
                Console.WriteLine("List of cars was serialized using XmlSerializer! Check cars.xml file");
            }
            using (FileStream fs = new FileStream(XmlFile, FileMode.Open))
            {
                var newList = (List<Car>)xs.Deserialize(fs);
                DisplayDeserializedObject(newList);
            }
            #endregion
            #region JsonSerializer
            JsonSerializer js = new JsonSerializer();
            using (StreamWriter writer = new StreamWriter(JsonFile))
            {
                using(JsonTextWriter jsWriter = new JsonTextWriter(writer))
                {
                    js.Serialize(jsWriter, cars);
                    Console.WriteLine("List of cars was serialized using JsonSerializer! Check cars.json file");
                }
            }
            using (JsonTextReader reader = new JsonTextReader(new StreamReader(JsonFile)))
            {
                var newList = (List<Car>) js.Deserialize(reader, typeof(List<Car>));
                DisplayDeserializedObject(newList);
            }
            #endregion
            
        }
        static void DisplayDeserializedObject(IEnumerable<Car> list)
        {
            Console.WriteLine("Deserialized object:");
            Console.WriteLine($"{"Id",5}{"Price",10}{"Quantity",15}{"Total price",16}");
            foreach (var car in list)
            {
                Console.WriteLine($"{car.carId,5}{car.price,10}{car.quantity,15} {car.total,15}");
            }
        }
    }
}
