using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.IO;

namespace LabWork8
{
    public class CollectionType<T> : IDefFunc<T> where T : class
    {
        public List<T> elements;
        private string savedInFilePath = @$"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork8\Obj.txt";

        public CollectionType()
        {
            elements = new List<T>();
        }

        public CollectionType(List<T> lst)
        {
            elements = lst;
        }

        public T this[int i]
        {
            get
            {
                return this.elements[i];
            }
            set
            {
                this.elements[i] = value;
            }
        }

        void IDefFunc<T>.Add(T a)
        {
            elements.Add(a);
        }
        void IDefFunc<T>.Delete(T a)
        {
            elements.Remove(a);
        }
        void IDefFunc<T>.View()
        {
            foreach (T a in elements)
            {
                Console.Write(a.ToString());
            }
            Console.WriteLine();
        }

        public void SaveObjJson()
        {
            string json = JsonSerializer.Serialize<List<T>>(this.elements);

            FileStream fileStream = new FileStream(savedInFilePath, FileMode.Create);
            byte[] arr = Encoding.Default.GetBytes(json);
            fileStream.Write(arr, 0, arr.Length);
            fileStream.Close();
        }

        public void BuildElementsFromJson()
        {
            StreamReader str = new StreamReader(savedInFilePath);
            string json = str.ReadToEnd();
            this.elements = JsonSerializer.Deserialize<List<T>>(json);
        }
    }

    public class CollectionType_struct<T> : IDefFunc<T> where T : struct
    {
        public List<T> elements;
        private string savedInFilePath = @$"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork8\Obj.txt";

        public CollectionType_struct()
        {
            elements = new List<T>();
        }

        public CollectionType_struct(List<T> lst)
        {
            elements = lst;
        }

        public T this[int i]
        {
            get
            {
                return this.elements[i];
            }
            set
            {
                this.elements[i] = value;
            }
        }

        void IDefFunc<T>.Add(T a)
        {
            elements.Add(a);
        }
        void IDefFunc<T>.Delete(T a)
        {
            elements.Remove(a);
        }
        void IDefFunc<T>.View()
        {
            foreach (T a in elements)
            {
                Console.Write(a.ToString());
            }
            Console.WriteLine();
        }

        public void SaveObjJson()
        {
            string json = JsonSerializer.Serialize<List<T>>(this.elements);

            FileStream fileStream = new FileStream(savedInFilePath, FileMode.Create);
            byte[] arr = Encoding.Default.GetBytes(json);
            fileStream.Write(arr, 0, arr.Length);
            fileStream.Close();
        }

        public void BuildElementsFromJson()
        {
            StreamReader str = new StreamReader(savedInFilePath);
            string json = str.ReadToEnd();
            this.elements = JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
