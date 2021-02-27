using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork5
{
    class Printer
    {
        public void iIAmPrinting(Vehicle[] all)
        {
            foreach(Vehicle n in all)
            {
                Console.WriteLine($"-{n.GetType()}");
                Console.WriteLine(n.ToString());
            }
        }
    }
}
