using LabWork7;
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
            try
            {
                Express express = new Express(new List<string>() { "Druzny", "Minsk" }, Vehicle.VehicleFields.EngineState.Stop, "BMV", 20, 100, 1, 1, 100);

                Console.WriteLine(express.fields.pureConsumption);

                Train train = new Train(
                    new List<Train.RailwayCarriage>()
                    {
                    new Train.RailwayCarriage((11, 11)),
                    },
                    Vehicle.VehicleFields.EngineState.Stop, 20, 30, 2, 1, 100
                );

                Engine car = new Car(Vehicle.VehicleFields.EngineState.Stop, "MERCEDES", 15, 8, 3, 2, 200);

                Vehicle train1 = new Train(train.carriages, Car.VehicleFields.EngineState.Stop, 10, 50, 4, 3, 300);

                Vehicle[] arr = new Vehicle[] { express, train, (car as Car) };

                TransportAgency transportAgency = new TransportAgency(
                    new List<Vehicle>() { express, train, (Car)car, train1 }
                    );

                transportAgency.OutVehiecles();

                Controller controller = new Controller(transportAgency);

                Console.WriteLine(controller.FindCarBySpeedRange(11, 100).fields.id);
            }
            catch(CarException e)
            {
                Console.WriteLine($"{e.Message} {e.brand}");
            }
            catch (VehicleException e)
            {
                Console.WriteLine($"{e.Message} {e.val}");
            }







            try
            {
                Train train2 = new Train(
                    new List<Train.RailwayCarriage>()
                    { },
                    Vehicle.VehicleFields.EngineState.Stop, 60, 30, 2, 1, 100
                );
            }
            catch (TrainException e)
            {
                Console.WriteLine($"{e.Message} {e.val}");

                try
                {
                    Train train2 = new Train(
                        new List<Train.RailwayCarriage>()
                        { new Train.RailwayCarriage((12, 12)) },
                        Vehicle.VehicleFields.EngineState.Stop, 20, 360, 2, 1, 100
                    );
                }
                catch (VehicleException m)
                {
                    Console.WriteLine($"{e.Message} {e.val}");
                }
                finally
                {
                    Console.WriteLine("Lots of bugs bro");
                }
            }
        }
    }
}
