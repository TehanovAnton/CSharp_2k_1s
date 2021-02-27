using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork10
{
    interface IEnumerator
    {
        object Current { get; }
        bool MoveNext();
        bool CanMoveNext();
        void Reset();
    }
}