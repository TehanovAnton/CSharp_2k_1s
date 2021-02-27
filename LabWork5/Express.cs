using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabWork5
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

        public Express(List<string> destinations, string brand, int plases, int speed, int id)
        {
            this.destinations = destinations;
            this.brand = brand;
            this.places = plases;
            this.speed = speed;
            this.id = id;
        }

        // переопределение virtual метода
        public override void VehicleType()
        {
            Console.WriteLine($"{this.GetType()} -> {base.GetType()}");
        }

        // переопределение наследуемых от Object
        public override string ToString()
        {
            return Convert.ToString(this.GetType()) + this.brand;
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
