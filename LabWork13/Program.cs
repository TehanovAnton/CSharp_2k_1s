using System;
using System.IO;

namespace OOP_SEM3_LAB13
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2)
            TAVDiskInfo Dinfo = new TAVDiskInfo();
            Dinfo.outDiskInfo();

            // 3)
            TAVFileInfo Finfo = new TAVFileInfo(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13\tavlogfile.txt");
            Finfo.outFileInfo();

            // 4)
            TAVDirInfo dirInfo = new TAVDirInfo(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13");
            dirInfo.outDirInfo();

            // 5)
            TAVFileManager FMInfo = new TAVFileManager(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13\TAVInspect", @"TAVdirinfo.txt", @"C:\");
            FMInfo.createDirAndFile();

            // 5b)
            TAVFileManager FMInfo2 = new TAVFileManager(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13", @"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13\TAVFiles");
            FMInfo2.CopyFilesFromDir();

            // 5c)
            TAVFileManager FMInfo3 = new TAVFileManager(@"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13\TAVFiles", @"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13");
            FMInfo3.ZipTask();
        }
    }
}