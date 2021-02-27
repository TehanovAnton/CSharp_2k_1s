using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork14
{
    [Serializable]
    public abstract class Vehicle
    {
        public abstract int speedAccessor { get; set; }
        public abstract int placesAccessor { get; set; }        
        public abstract int IdAccessor { get; }
        public abstract void Repaire();
        public abstract void Status();
    }
}
