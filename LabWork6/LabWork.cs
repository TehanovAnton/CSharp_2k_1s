using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Schema;

namespace LabWork6
{
    class LabWork
    {
        static void Main()
        {
            Express express = new Express(new List<string>() { "Druzny", "Minsk" }, Vehicle.VehicleFields.EngineState.Stop, "BMV" , 10, 20, 1, 1, 100);

            Console.WriteLine(express.fields.pureConsumption);

            Train train = new Train(
                new List<Train.RailwayCarriage>()
                { 
                    new Train.RailwayCarriage((11, 11)),
                    new Train.RailwayCarriage((12, 12))
                },
                Vehicle.VehicleFields.EngineState.Stop, 20, 30, 2, 1,100
            );

            Engine car = new Car(Vehicle.VehicleFields.EngineState.Stop, "MERCEDES", 90, 8, 3, 2, 200);

            Vehicle train1 = new Train(train.carriages, Car.VehicleFields.EngineState.Stop, 50, 50, 4, 3, 300);

            Vehicle[] arr = new Vehicle[] { express, train, (car as Car)};

            TransportAgency transportAgency = new TransportAgency(
                new List<Vehicle>() { express, train, (Car)car , train1}
                );

            transportAgency.OutVehiecles();

            Controller controller = new Controller(transportAgency);

            Console.WriteLine(controller.FindCarBySpeedRange(11, 100).fields.id);
        }
    }
}
