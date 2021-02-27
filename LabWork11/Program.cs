using System;
using System.Linq;
using System.Collections.Generic;

namespace LabWork11
{
    class Program
    {
        public static void Outer(string header, string[] monthes)
        {
            Console.WriteLine(header);
            foreach (var i in monthes)
                Console.WriteLine(string.Format("\t{0}", i));
            Console.WriteLine();
        }

        public static void Outer(string header, List<Train> trains)
        {
            Console.WriteLine(header);
            foreach (var i in trains)
                Console.WriteLine(string.Format("\tTrain -> id:{0}, destination: {1}", i.ID, i.destinantionAccessor));
            Console.WriteLine();
        }

        public static void FirstPart()
        {
            string[] monthes =
                { 
                    "January", "february", "March", "Aprel", "May", "June", "July", "August", "September", "October", "November", "December"
            };

            Outer("1) Месяцы с длинной названия не более 5:",
                (from n in monthes where n.Length <= 5 select n).ToArray());

            int[] winterSumerMonthesIndexes = { 0, 1, 5, 6, 7, 11 };
            Outer("2) Зимнеие и летние месяцы:",
                (from n in monthes where winterSumerMonthesIndexes.Contains(Array.IndexOf(monthes, n)) select n).ToArray());

            Outer("3) Месяцы в алфавитном порядке:",
                (from n in monthes orderby n select n).ToArray());

            Outer("4) Месяцы имюещие в названии букву \"u\" и длинной не менее 4:",
                (from n in monthes where n.Length >= 4 && n.Contains('u') select n).ToArray());
        }

        public static void SecondThirdPart(List<Train> trains)
        {
            Outer("cсписок поездов следующих до C:",
                (from n in trains where n.destinantionAccessor == "C" select n).ToList());

            Outer("cсписок поездов следующих до B отправляющихся после 10:",
                (from n in trains where n.destinantionAccessor == "B" && n.depatureTimeAccessor.houre > 10 select n).ToList());

            Outer("поезд с наибольшим количеством мест:",
                (from n in trains where n.TotalSeatsNumer() == trains.Select(n => n.TotalSeatsNumer()).Max() select n).ToList());

            Outer("последние 5 поезд по времени отправления:",
                (from n in trains.OrderByDescending(n => n.depatureTimeAccessor.houre).Take(5) select n).ToList());

            Outer("лист поездов в алфавитном порядке:",
            (from n in trains orderby n.destinantionAccessor select n).ToList());
        }

        public static void FourthPart(List<Train> trains)
        {
            Console.WriteLine("запрос с 5 операторами: " +
                (from n in trains.OrderByDescending(n => n.ID).Take(5) where n.commonPlacesAccessor > 2 select n.depatureTimeAccessor).Count(n => n.houre > 11));
        }

        static void Main(string[] args)
        {
            FirstPart();

            List<Train> trains = new List<Train>();
            uint cmPl = 1, cmprtPl = 1, rsrvPl = 1, lxrPl = 1;
            uint dstntn = (uint)'A';
            for (uint i = 0; i < 8; i++)
                trains.Add(new Train(Convert.ToString((char)(dstntn + i)), (uint)(i + 1), ((byte)(10 + i),
                        0), cmPl + i, cmprtPl + i, rsrvPl + i, lxrPl + i + 1));

            SecondThirdPart(trains);

            FourthPart(trains);

            int[] lenthes = { 1, 4, 5, 6};
            string[] monthes = { "January", "February", "March", "Aprel", "May", "June", "July", "August", "September", "October", "November", "December" };
            var res = monthes.Join(
                lenthes,
                n => n.Length,
                m => m,
                (n, m) => new { n = n, m = m }
                );
            foreach(var i in res)
            {
                Console.WriteLine(string.Format("{0} {1}", i.n, i.m));
            }
        }
    }
}