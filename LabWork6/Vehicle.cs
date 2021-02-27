using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork6
{
    public abstract class Vehicle
    {
        public struct VehicleFields
        {
            public enum EngineState
            {
                Work,
                Stop,
                Repaire
            }
            public EngineState engineState { get; set; }
            public int speed { get; set; }
            public int places { get; set; }
            public int id { get; set; }
            public int pureConsumption { get; set; }
            public int cost { get; set; }

            public VehicleFields(EngineState engineState, int speed, int places, int id, int pureConsumption, int cost)
            {
                this.engineState = engineState;
                this.speed = speed;
                this.places = places;
                this.id = id;
                this.pureConsumption = pureConsumption;
                this.cost = cost;
            }
        }

        public VehicleFields fields;
        public abstract void Repaire();
        public abstract void Status();
    }
}
