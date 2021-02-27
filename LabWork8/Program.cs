using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace LabWork8
{
    class Program
    {
        public static void Type_struct()
        {
            CollectionType_struct<int> collectionInt = new CollectionType_struct<int>();
            for (int i = 0; i < 10; i++)
            {
                ((IDefFunc<int>)collectionInt).Add(i);
            }
            ((IDefFunc<int>)collectionInt).View();

            for (int i = 0; i < collectionInt.elements.Count; i++)
            {
                if (collectionInt.elements[i] % 2 == 0)
                {
                    ((IDefFunc<int>)collectionInt).Delete(collectionInt.elements[i]);
                }
            }
            ((IDefFunc<int>)collectionInt).View();
            Console.WriteLine();
        }

        public static void Type_class()
        {
            CollectionType<string> collectionString = new CollectionType<string>();
            for (int i = (int)'a'; i < (int)'z'; i++)
            {
                ((IDefFunc<string>)collectionString).Add(Convert.ToString((char)i));
            }
            ((IDefFunc<string>)collectionString).Add(Convert.ToString('z'));

            ((IDefFunc<string>)collectionString).View();
            int part = collectionString.elements.Count / 2;
            for (int i = 0; i < part; i++)
            {
                ((IDefFunc<string>)collectionString).Delete(collectionString.elements[0]);
            }
            ((IDefFunc<string>)collectionString).View();
            Console.WriteLine();

            collectionString.SaveObjJson();
            collectionString.elements = null;
            Console.WriteLine("Elements saved then zeroed:");

            Console.WriteLine("Elements restored:");
            collectionString.BuildElementsFromJson();
            ((IDefFunc<string>)collectionString).View();
            Console.WriteLine();

            // Car
            CollectionType<Car> collectionCar = new CollectionType<Car>();
            for (int i = 0, e = (int)'A'; i < 5; i++, e++)
            {
                ((IDefFunc<Car>)collectionCar).Add(new Car(Convert.ToString((char)e), i + 1, 30, (i + 1) * 2));
            }
            ((IDefFunc<Car>)collectionCar).View();

            part = collectionCar.elements.Count / 2;
            for (int i = 0; i < part; i++)
            {
                ((IDefFunc<Car>)collectionCar).Delete(collectionCar.elements[0]);
            }
            ((IDefFunc<Car>)collectionCar).View();
        }
        static void Main(string[] args)
        {
            try
            {
                Type_struct();

                Type_class();
            }
            finally
            {
                Console.WriteLine("Выполнение завершеннно");
            }
        }
    }
}
