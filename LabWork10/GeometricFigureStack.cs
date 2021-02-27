using System;
using System.Collections.Generic;
using System.Text;

namespace LabWork10
{
    class GeometricFigureStack
{
        public Stack<GeometricFigure> figuresStack;

        public GeometricFigureStack(Stack<GeometricFigure> figuresStack)
        {
            this.figuresStack = figuresStack;
        }

        public void Veiw()
        {
            foreach (GeometricFigure i in figuresStack)
                Console.WriteLine(i.figureName);

            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            return new GeometricFigureStackEnumerator(figuresStack);
        }
    }
}
