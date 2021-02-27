using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace LabWork12
{
    static class Reflector
    {
        // a)
        public static void GetAssemblyName(Type type)
        {
            Console.WriteLine(string.Format("Имя сборки:\n\t{0}", Assembly.GetAssembly(type).FullName));
        }

        // b)
        public static void HasPublicFields(Type type)
        {
            Console.WriteLine(string.Format("Тип не имеет публичных полей: {0}", type.GetFields().Length == 0));
        }

        // c)
        public static void GetPublicMethods(Type type)
        {
            Console.WriteLine("публичные методы типа:");
            foreach(var i in type.GetMethods())
            {
                Console.WriteLine(i.Name);
            }
        }

        // d)
        public static void GetFieldsPropeties(Type type)
        {
            Console.WriteLine("Fields:");
            foreach(var i in type.GetFields())
            {
                Console.WriteLine(string.Format("\t {0}", i.Name));
            }

            Console.WriteLine("Properties:");
            foreach (var i in type.GetProperties())
            {
                Console.WriteLine(string.Format("\t {0}", i.Name));
            }
        }

        // e)
        public static void GetInterfaces(Type type)
        {
            Console.WriteLine("Interfaces:");
            foreach (var i in type.GetInterfaces())
            {
                Console.WriteLine(string.Format("\t {0}", i.Name));
            }
        }

        // f)
        public static void GetMethodWithSpecTypeParms(Type sourceClass, Type typeParm)
        {
            MethodInfo[] methods = sourceClass.GetMethods();

            IEnumerable<MethodInfo> m =
                from n in methods where
                Array.Exists<ParameterInfo>(n.GetParameters(), n => n.ParameterType == typeParm) select n;

            foreach(var i in m)
            {
                Console.WriteLine(i.Name);
            }
        }

        // g)
        public static void Invoke(object obj, string methodName, object[] parms)
        {
            Console.WriteLine("вызов метода:\n");
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(Activator.CreateInstance(type), parms);
        }

        // 2)
        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
