using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LabWork6
{
    public class Controller : TransportAgency
    {
        public Controller(TransportAgency el)
        {
            vehicles = el.vehicles;
        }

        public int SumVehicleCost()
        {
            int sum = 0;
            for(int i = 0; i < vehicles.Count; i++)
            {
                sum += vehicles[i].fields.cost;
            }

            return sum;
        }

        public void SortVehiclesByPureConsumtion()
        {
            vehicles.Sort((a, b) => a.fields.pureConsumption.CompareTo(b.fields.pureConsumption));
        }

        public Vehicle FindCarBySpeedRange(int f, int l)
        {
            return vehicles.Find((a) => (a is Car) && f <= a.fields.speed && a.fields.speed <= l);
        }
    }
}
