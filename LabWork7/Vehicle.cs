using LabWork7;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LabWork6
{
    public abstract class Vehicle
    {
        private static int SetIfValid(int maxValue, int value, string exceptionMessage)
        {
            if (value > maxValue || value <= 0)
            {
                throw new VehicleException(exceptionMessage, value);
                // "значение превышает максимально допустимое"
            }
            else
            {
                return value;
            }
        }

        public struct VehicleFields
        {
            public enum EngineState
            {
                Work,
                Stop,
                Repaire
            }
            public EngineState engineState 
            { 
                get; 
                set; 
            }

            public int speed { get; set; }
            public int places { get; set; }
            public int id { get; set; }
            public int pureConsumption { get; set; }
            public int cost { get; set; }

            public VehicleFields(EngineState engineState, int places, int speed, int id, int pureConsumption, int cost)
            {
                this.engineState = engineState;
                this.speed = SetIfValid(350, speed, "превышенно максимальное значение скорости");
                this.places = SetIfValid(25, places, "превышенно максимальное значение мест");
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
