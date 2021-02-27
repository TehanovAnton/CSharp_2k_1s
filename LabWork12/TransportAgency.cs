using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LabWork12
{
    public class TransportAgency
    {
        public List<Vehicle> vehicles { get; set; }

        public TransportAgency()
        {
            vehicles = new List<Vehicle>();
        }

        public TransportAgency(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public Vehicle this[int i]
        {
            get
            {
                return vehicles[i];
            }
            set
            {
                vehicles[i] = value;
            }
        }

        public void AddVehiecle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void deleteLastVehiecle()
        {
            vehicles.RemoveAt(vehicles.Count);
        }

        public void OutVehiecles()
        {
            Console.WriteLine($"Vehicle amount: {vehicles.Count}");
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{vehicles[i].ToString()}");
            }
        }
    }
}
