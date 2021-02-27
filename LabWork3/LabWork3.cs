using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

public partial class Train
{
    private const uint maxTrainNumber = 100;
    private string destinantion;
    private uint trainNumber;
    private (byte houre, byte minute) depatureTime;
    private uint commonPlaces;
    private uint compartmentPlaces;
    private uint reservedPlaces;
    private uint luxuryPlaceces;
    public readonly uint ID;
    public static uint amountCreatedElements;

    public uint maxTrainNumberAccessor
    {
        get
        {
            return maxTrainNumber;
        }
    }
    public string destinantionAccessor
    {
        set
        {
            if (value != "")
            {
                destinantion = value.ToString();
            }
            else
            {
                Console.WriteLine("destinantion setValue Error");
            }
        }
        get
        {
            return destinantion;
        }
    }
    public uint trainNumberAccessor
    {
        set
        {
            if (value > 0 && value <= maxTrainNumber)
            {
                trainNumber = Convert.ToUInt32(value);
            }
            else
            {
                Console.WriteLine("trainNumber setValue Error");
            }
        }
        get
        {
            return trainNumber;
        }
    }
    public (byte houre, byte minute) depatureTimeAccessor
    {
        set
        {
            if (value.houre >= 0 && value.houre <= 23 && value.minute >= 0 && value.minute <= 59)
            {
                depatureTime = value;
            }
            else
            {
                Console.WriteLine("trainNumber setValue Error");
            }
        }
        get
        {
            return depatureTime;
        }
    }
    public uint commonPlacesAccessor
    {
        set
        {
            if (commonPlaces >= 0)
            {
                commonPlaces = value;
            }
            else
            {
                Console.WriteLine("commonPlaces setValue Error");
            }
        }
        get
        {
            return commonPlaces;
        }
    }
    public uint compartmentPlacesAccessor
    {
        set
        {
            if (compartmentPlaces >= 0)
            {
                compartmentPlaces = value;
            }
            else
            {
                Console.WriteLine("compartmentPlaces setValue Error");
            }
        }
        get
        {
            return compartmentPlaces;
        }
    }
    public uint reservedPlacesAccessor
    {
        set
        {
            if (reservedPlaces >= 0)
            {
                reservedPlaces = value;
            }
            else
            {
                Console.WriteLine("compartmentPlaces setValue Error");
            }
        }
        get
        {
            return reservedPlaces;
        }
    }
    public uint luxuryPlacecesAccessor
    {
        set
        {
            if (luxuryPlaceces >= 0)
            {
                luxuryPlaceces = value;
            }
            else
            {
                Console.WriteLine("compartmentPlaces setValue Error");
            }
        }
        get
        {
            return luxuryPlaceces;
        }
    }

    // конструктор без параметров
    public Train()
    {
        ID = (uint)this.GetHashCode();
        amountCreatedElements++;
    }
    // конструктор с параметрами
    public Train(string destinantion, uint trainNumber, (byte houre, byte minute) depatureTime, uint commonPlaces,
        uint compartmentPlaces, uint reservedPlaces, uint luxuryPlaceces)
    {
        this.destinantion = destinantion;
        this.trainNumber = trainNumber;
        this.depatureTime = depatureTime;
        this.commonPlaces = commonPlaces;
        this.compartmentPlaces = compartmentPlaces;
        this.reservedPlaces = reservedPlaces;
        this.luxuryPlaceces = luxuryPlaceces;
        ID = (uint)this.GetHashCode();
        amountCreatedElements++;
    }
    // конструктор с параметрами по умолчанию 
    public Train(string destinantion = "minsk", uint trainNumber = 0) : this()
    {
        this.destinantion = destinantion;
        this.trainNumber = trainNumber;
        ID = (uint)this.GetHashCode();
        amountCreatedElements++;
    }

    static Train()
    {
        amountCreatedElements = 0;
    }

    // вывод общего числа мест
    public void TotalSeatsNumer()
    {
        Console.WriteLine(commonPlaces + compartmentPlaces + reservedPlaces + luxuryPlaceces);
    }

    // статический метод вывода информации об калссе
    public void GetClassInformation()
    {
        Console.WriteLine(
            "Class name: Train\n" +
            $"amount created elements: {Train.amountCreatedElements}");
    }

    // перегрузка Equals
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
        {            
            return false;
        }

        Train train = (Train)obj;
        return this.trainNumber == train.trainNumber;
    }

    // перегрузка GetHash
    public override int GetHashCode()
    {
        int hash = string.IsNullOrEmpty(this.destinantionAccessor) ? 0 : this.destinantionAccessor.GetHashCode();
        return hash * 47;
    }

    // перегрузка Tostring
    public override string ToString()
    {
        return "Type" + base.ToString() + this.destinantionAccessor;
    }
}

public partial class Train
{
    // выводит список элементов идущих до заданной остановки
    public static void GetListElDestination(Train[] trains, string destination, ref uint res)
    {
        Console.WriteLine($"до станции {destination}, идут поезда:");
        for (uint i = 0; i < trains.GetLength(0); i++)
        {
            if (trains[i].destinantion == destination)
            {
                Console.WriteLine($"{trains[i].trainNumber}");
                res++;
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine($"количество подходящих поездов: {res}\n");
    }

    // выводит список поездов идущих до заданной остановки после заданного времни
    public static void GetListElDestinationAfter(Train[] trains, string destination, (byte houre, byte minute) time, out uint res)
    {
        Console.WriteLine($"до станции {destination} после {time.houre}:{time.minute}, идут поезда:");
        res = 0;
        for (uint i = 0; i < trains.GetLength(0); i++)
        {
            bool afterTime = (trains[i].depatureTime.houre > time.houre) ||
                (trains[i].depatureTime.houre == time.houre && trains[i].depatureTime.minute > time.minute);
            if (trains[i].destinantion == destination && afterTime)
            {
                Console.WriteLine($"{trains[i].trainNumber}");
                res++;
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine($"количество подходящих поездов: {res}\n");
    }
}


namespace LabWork3
{
    class LabWork3
    {
        static void Main(string[] args)
        {
            Train[] trains = new Train[6];
            uint cmPl = 1, cmprtPl = 1, rsrvPl = 1, lxrPl = 1;           
            uint dstntn = (uint)'A';
            for (uint i = 0; i < trains.GetLength(0); i++)
            {
                trains[i] = new Train(Convert.ToString((char)(dstntn + i)), (uint)(i + 1), ((byte)(10 + i),
                    (byte)(i * 10)), cmPl + i, cmprtPl + i, rsrvPl + i, lxrPl + i);
            }

            uint res = 0;
            Train.GetListElDestination(trains, "A", ref res);

            uint rEs;
            Train.GetListElDestinationAfter(trains, "B", (10,0),out rEs);

            Console.WriteLine($"\n{Train.amountCreatedElements}\n");

            var anonimType = new { trainNumber = 0, destination = "A" };

            Object el;
        }
    }
}
