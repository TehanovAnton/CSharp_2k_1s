using LabWork6;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork7
{
    public class VehicleException : Exception
    {
        public int val {get;}
        public VehicleException(string message, int val):base(message)
        {
            this.val = val;
        }

        public VehicleException(string message) : base(message)
        {           
        }
    }

    public class CarException : VehicleException
    {
        public string brand { get; }
        public CarException(string message, string val) : base(message)
        {
            this.brand = val;
        }
    }

    public class TrainException : VehicleException
    {       
        public List<Train.RailwayCarriage> carriages { get; }
        public TrainException(string message, List<Train.RailwayCarriage> val) : base(message)
        {
            this.carriages = val;
        }
    }
}
