using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork8
{
    interface IDefFunc<T>
    {
        void Add(T a);
        void Delete(T a);
        void View();
    }
}
