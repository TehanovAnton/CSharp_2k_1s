using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork10
{
    class GeometricFigureStackEnumerator : IEnumerator
    {
        private Stack<GeometricFigure> figuresStack;
        private int position;

        public GeometricFigureStackEnumerator(Stack<GeometricFigure> figuresStack)
        {
            this.figuresStack = figuresStack;
            position = -1;
        }

        public bool CanMoveNext() => position < figuresStack.Count - 1;

        public bool MoveNext()
        {
            if (CanMoveNext())
                position++;            
            else
                return false;

            return true;
        }

        public object Current
        {
            get
            {
                if (position < figuresStack.Count)
                    return figuresStack.ToArray()[position];
                else
                    throw new InvalidOperationException();
            }
        }

        public void Reset() => position = -1;
    }
}
