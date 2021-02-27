using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Schema;

namespace LabWork5
{
    class Program
    {
        static void Main()
        {
            Express express = new Express(new List<string>() { "Druzny", "Minsk" }, "BMV" , 10, 20, 1);
            ((Engine)express).Move();
            ((Engine)express).Status();
            ((Engine)express).Stop();
            express.Status();
            express.Repaire();
            express.ToString();

            Console.WriteLine("\n");

            Train train = new Train(new List<Train.RailwayCarriage>() { new Train.RailwayCarriage((11, 11)), new Train.RailwayCarriage((12, 12)) }, 20, 30, 2);
            ((Engine)train).Move();
            ((Engine)train).Status();
            ((Engine)train).Stop();
            train.Status();
            train.Repaire();
            train.ToString();

            Console.WriteLine("\n");

            Engine car = new Car("MERCEDES", 90, 8, 3);
            if (car is Car)
            {
                Console.WriteLine($"Car Id? {(car as Car).IdAccessor}");
            }
            (car as Car).ToString();

            Vehicle train1 = new Train( train.carriages, 50, 50, 4);
            if (train1 is Train)
            {
                Console.WriteLine($"Train Id? {(train1 as Train).IdAccessor}");
            }
            (train1 as Train).ToString();

            Console.WriteLine("\n");

            Vehicle[] arr = new Vehicle[] { express, train, (car as Car)};
            Printer printer = new Printer();
            printer.iIAmPrinting(arr);
        }
    }
}
