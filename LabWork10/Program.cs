using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LabWork10
{
    class Program
    {
        public static void GeometricFigure_CollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"добавленна фигура: {(e.NewItems[0] as GeometricFigure).figureName}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"удалена фигура: {(e.OldItems[0] as GeometricFigure).figureName}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine($"фигура: {(e.OldItems[0] as GeometricFigure).figureName} заменена на: {(e.NewItems[0] as GeometricFigure).figureName}");
                    break;
            }
        }

        static void Main(string[] args)
        {
            // first
            Console.WriteLine("первая часть\n");

            Stack<GeometricFigure> figures = new Stack<GeometricFigure>();
            for (int i = (int)'A'; i < (int)'A' + 5; i++)
            {
                figures.Push(new GeometricFigure(Convert.ToString((char)i)));
            }

            GeometricFigureStack figuresStack = new GeometricFigureStack(figures);
            figuresStack.Veiw();

            figuresStack.figuresStack.Push(new GeometricFigure(Convert.ToString('A')));
            figuresStack.Veiw();

            figuresStack.figuresStack.Pop();
            figuresStack.Veiw();

            // second
            Console.WriteLine("вторая часть\n");

            Stack<char> stck = new Stack<char>();
            foreach (char i in "anton Tehanov")
                stck.Push(i);

            foreach (char i in stck)
                Console.Write(i);

            stck.Pop();
            stck.Pop();
            stck.Pop();
            Console.WriteLine($"\n{stck.Pop()}\n");

            List<char> list = new List<char>();
            foreach (char i in stck)
                list.Add(i);

            foreach (char i in list)
                Console.Write(i);

            Console.WriteLine($"\n\n{list.IndexOf('e')}");

            // third
            Console.WriteLine("третья часть\n");

            var element = new ObservableCollection<GeometricFigure>
            {
                new GeometricFigure("квадрат"),
                new GeometricFigure("треугольник"),
                new GeometricFigure("круг")
            };
            element.CollectionChanged += GeometricFigure_CollectionChanged;

            element.Add(new GeometricFigure("ромб"));
            element.RemoveAt(1);
            element[1] = new GeometricFigure("прямоугольник");
        }
    }
}
