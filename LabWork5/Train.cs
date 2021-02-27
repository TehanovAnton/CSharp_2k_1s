using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabWork5
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
        public int speed;
        public int places;
        public int id;
        private bool engineStatus;


        public Train()
        {
            this.engineStatus = false;
        }

        public Train(List<RailwayCarriage> carriages, int speed, int places, int id)
        {
            this.carriages = carriages;
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

        public override void Repaire()
        {
            Console.WriteLine($"{this.GetType()} (id -> {this.id}) is repaired ");
        }

        public override void Status()
        {
            if (this.engineStatus)
            {
                Console.WriteLine("Train is moving");
            }
            else
            {
                Console.WriteLine("Train isnt moving");
            }
        }

        public override string ToString()
        {
            return $"Type:{this.GetType()} {this.engineStatus}";
        }
    }
}
