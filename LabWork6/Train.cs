using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabWork6
{
    public sealed class Train : Vehicle, Engine
    {
        public class RailwayCarriage
        {
            public (int length, int height) carriage;

            public RailwayCarriage((int length, int height) carriage)
            {
                this.carriage = carriage;
            }
        }

        public List<RailwayCarriage> carriages;

        public Train()
        {
            this.fields = new Car.VehicleFields();
        }

        public Train(List<RailwayCarriage> carriages, Car.VehicleFields.EngineState engineState, int speed, int places, int id, int pureConsumption, int cost)
        {
            this.carriages = carriages;
            fields = new Car.VehicleFields(engineState, speed, places, id, pureConsumption, cost);
        }

        void Engine.Move()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.fields.id}) is moveing now");
            this.fields.engineState = Car.VehicleFields.EngineState.Work;
        }

        void Engine.Stop()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.fields.id}) has stoped");
            this.fields.engineState = Car.VehicleFields.EngineState.Stop;
        }

        void Engine.Status()
        {
            string engState =
            this.fields.engineState == Car.VehicleFields.EngineState.Work ?
                "Engine On" : "Engine Off";
            Console.WriteLine(engState);
        }

        public override void Repaire()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.fields.id}) is repaired ");
        }

        public override void Status()
        {
            string trainState =
            this.fields.engineState == Car.VehicleFields.EngineState.Work ?
                "Train is moving" : "Train isnt moving";
            Console.WriteLine(trainState);
        }

        public override string ToString()
        {
            string engState =
            this.fields.engineState == Car.VehicleFields.EngineState.Work ?
                "On" : "Off";
            
            return $"Type:{this.GetType()} {engState}, carriages count: {this.carriages.Count}, {this.fields.id} {this.fields.places} {this.fields.speed}";
        }

    }
}
