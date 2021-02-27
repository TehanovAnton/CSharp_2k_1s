using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabWork12
{
    public sealed class Express : Car
    {
        public List<string> destinations;

        public string this[int i]
        {
            get
            {
                return this.destinations[i];
            }
            set
            {
                this.destinations[i] = value;
            }
        }

        public Express(List<string> destinations, Vehicle.VehicleFields.EngineState engstate, string brand, int plases, int speed, int id, int pureConsumption, int cost):
            base(engstate, brand, plases, speed, id, pureConsumption, cost)
        {
            this.destinations = destinations;
        }

        // переопределение virtual метода
        public override void VehicleType()
        {
            Console.WriteLine($"{this.GetType()} -> {base.GetType()}");
        }

        // переопределение наследуемых от Object
        public override string ToString()
        {
            return $"Type:{this.GetType()} {this.brand} {this.fields.id} {this.fields.engineState} {this.fields.places} {this.fields.speed}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 2;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == ((Express)obj).GetHashCode();
        }
    }
}
