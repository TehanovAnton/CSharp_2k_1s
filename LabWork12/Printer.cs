using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork12
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
