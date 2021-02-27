using System;

namespace LabWork12
{
    class Program
    {
        public static void ReflectorCar(Type type)
        {
            Reflector.GetAssemblyName(type);

            Reflector.HasPublicFields(type);

            Reflector.GetPublicMethods(type);

            Reflector.GetFieldsPropeties(type);

            Reflector.GetInterfaces(type);

            Reflector.Invoke(Activator.CreateInstance(type), "Status", new object[] {});

            Console.WriteLine("---------------------------------");
        }

        public static void ReflectorTrain(Type type)
        {
            Reflector.GetAssemblyName(type);

            Reflector.HasPublicFields(type);

            Reflector.GetPublicMethods(type);

            Reflector.GetFieldsPropeties(type);

            Reflector.GetInterfaces(type);

            Reflector.Invoke(Activator.CreateInstance(type), "ToString", new object[] { });

            Console.WriteLine("---------------------------------");
        }

        public static void ReflectorInt(Type type)
        {
            Reflector.GetAssemblyName(type);

            Reflector.HasPublicFields(type);

            Reflector.GetPublicMethods(type);

            Reflector.GetFieldsPropeties(type);

            Reflector.GetInterfaces(type);

            Reflector.GetMethodWithSpecTypeParms(type, typeof(Int32));

            Console.WriteLine("---------------------------------");
        }

        static void Main(string[] args)
        {
            ReflectorCar(typeof(Car));

            ReflectorCar(typeof(Train));

            ReflectorInt(typeof(Int32));

            var i = Convert.ToInt32(Reflector.Create(typeof(Int32)));
            Console.WriteLine(string.Format("creatr inst {0}", i));
        }
    }
}
