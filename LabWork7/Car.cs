using LabWork7;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace LabWork6
{
    public partial class Car : Vehicle, Engine
    {
        private static string SetIfValid(string notValidBrand, string value, string exceptionMessage)
        {
            if (value == notValidBrand)
            {
                throw new CarException(exceptionMessage, value);
                // "значение превышает максимально допустимое"
            }
            else
            {
                return value;
            }
        }

        public Car()
        {
            fields = new VehicleFields();
        }
        public Car(VehicleFields.EngineState engineState, string brand, int speed, int places, int id, int pureConsumption, int cost)
        {
            this.brand = SetIfValid("MERCEDES", brand, "недопустимая марка авто");
            fields = new VehicleFields(engineState, speed, places, id, pureConsumption, cost);
        }

        void Engine.Move()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.fields.id}) is moveing now");
            this.fields.engineState = VehicleFields.EngineState.Work;
        }

        void Engine.Stop()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.fields.id}) has stoped");
            this.fields.engineState = VehicleFields.EngineState.Stop;
        }

        void Engine.Status()
        {
            if (this.fields.engineState == VehicleFields.EngineState.Work)
            {
                Console.WriteLine("Engine On");
            }
            else
            {
                Console.WriteLine("Engine Off");
            }
        }

        public virtual void VehicleType()
        {
            Console.WriteLine(this.GetType());
        }

        public override void Repaire()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.fields.id}) is repaired");
        }

        public override void Status()
        {
            if (this.fields.engineState == VehicleFields.EngineState.Work)
            {
                Console.WriteLine("Car is moving");
            }
            else
            {
                Console.WriteLine("Car isnt moving");
            }
        }

        public override string ToString()
        {
            string engState =
                this.fields.engineState != VehicleFields.EngineState.Work ?
                this.fields.engineState != VehicleFields.EngineState.Stop ? 
                "Off" : "OFf" : "On";

            return $"Type:{this.GetType()} {engState} {this.brand} {this.fields.id} {this.fields.places} {this.fields.speed}";
        }
    }
}
