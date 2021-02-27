using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace LabWork14
{
    [Serializable]
    public class Car : Vehicle, Engine
    {
        public string brand;
        public int speed;
        public int places;
        [NonSerialized]
        public int id;
        private bool engineStatus;

        public string brandAccessor
        {
            get
            {
                return brand;
            }
        }     
        public Car()
        {
            this.engineStatus = false;
        }
        public Car(string brand, int speed, int places, int id)
        {
            this.brand = brand;
            this.speed = speed;
            this.places = places;
            this.id = id;
            this.engineStatus = false;
        }

        public override int speedAccessor
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }
        public override int placesAccessor
        {
            get
            {
                return this.places;
            }
            set
            {
                this.places = value;
            }
        }
        public override int IdAccessor
        {
            get
            {
                return this.id;
            }
        }

        void Engine.Move()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.id}) is moveing now");
            this.engineStatus = true;
        }

        void Engine.Stop()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.id}) has stoped");
            this.engineStatus = false;
        }

        void Engine.Status()
        {
            if (this.engineStatus)
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
            Console.WriteLine($"{this.GetType()} (id -> {this.id}) is repaired");
        }

        public override void Status()
        {
            if (this.engineStatus)
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
            return $"Type:{this.GetType()} {this.engineStatus}";
        }
    }
}
