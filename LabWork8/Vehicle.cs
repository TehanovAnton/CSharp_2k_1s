using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork8
{
    public abstract class Vehicle
    {      
        public abstract int speedAccessor { get; set; }
        public abstract int placesAccessor { get; set; }
        public abstract int IdAccessor { get; set; }
        public abstract void Repaire();
        public abstract void Status();
    }
}
