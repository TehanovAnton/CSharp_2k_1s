using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class List
{
    public class Owner
    {
        public uint ID;
        public string orgName;

        public Owner()
        {
            ID = (uint)this.GetHashCode();
            orgName = "yahoo";
        }
    }

    public class Date
    {
        public DateTime dateCreate;
        public Date()
        {
            dateCreate = new DateTime();
            dateCreate = DateTime.Now;
        }
    }

    public List<string> elements;
    public Owner owner;
    public Date date;

    public List()
    {
        elements = new List<string>();
        owner = new Owner();
        date = new Date();
    }

    public List(List<string> lst)
    {
        elements = lst;
        owner = new Owner();
        date = new Date();
    }

    public string this[int i]
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

    public static List operator +(List lst, string word)
    {
        lst.elements.Add(word);
        return lst;
    }

    public static List operator --(List lst)
    {
        lst.elements.RemoveRange(lst.elements.Count - 1, 1);
        return lst;
    }

    // равны если имеют равное количество элементов и расопложенные в одном порядке
    public static bool operator ==(List lst1, List lst2)
    {
        bool orederliness = true;

        if (lst1.elements.Count == lst2.elements.Count)
        {
            for (int i = 0; i < lst1.elements.Count; i++)
            {
                orederliness &= lst1.elements[i] == lst2.elements[i];
            }
        }
        else
        {
            return false;
        }

        return orederliness;
    }

    public static bool operator !=(List lst1, List lst2)
    {
        return !(lst1 == lst2);
    }
}

public static class StaticOperation
{
    public static int NumElements(this List<string> elements)
    {
        return elements.Count;
    }

    public static bool EmptyElements(this List<string> elements)
    {
        return elements.Contains("");
    }
}

namespace LabWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            List list1 = new List(new List<string>() { "anton", "tehaonv", "victorovich" , ""});           

            List list2 = new List(new List<string>() { "anton", "tehaonv", "victorovich"});

            Console.WriteLine(list2 != list1);

            list1--;

            Console.WriteLine(list1 != list2);

            Console.WriteLine($"NumWords: {list1.elements.NumElements()}, EmptyWords: {list1.elements.EmptyElements()}\n" +
                $"{list1.owner.ID} {list1.owner.orgName}\n" +
                $"{list1.date.dateCreate}\n" +
                $"{list1[0]}");            
        }
    }
}
