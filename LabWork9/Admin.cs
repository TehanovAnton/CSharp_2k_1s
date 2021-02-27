using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork9
{
    class Admin
    {
        public delegate void Func();

        public event Func upgrade;
        public event Func work;

        public void Update()
        {
            upgrade();
        }

        public void StartWork()
        {
            work();
        }
    }
}
