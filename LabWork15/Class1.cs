using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork15
{
    class Class1
    {
        public int Factorial(int i)
        {
            int factorial = 1;
            for(int e = i; e > 1; e--)
            {
                factorial *= e;
            }

            return factorial;
        }
    }
}
