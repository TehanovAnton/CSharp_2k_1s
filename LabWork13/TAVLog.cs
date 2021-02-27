using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_SEM3_LAB13
{
    static class TAVLog
    {
        private static string tavlogfileFullName = @"C:\Users\Anton\source\repos\Пацей Наталья Владимировна\решение лабароторных работ\LabWork13\tavlogfile.txt";
        private static FileInfo tavlogfile;
        private static FileStream tavlogfileStream;

        static TAVLog()
        {
            tavlogfile = new FileInfo(tavlogfileFullName);
        }

        public static void LogChange(string change)
        {
            tavlogfileStream = tavlogfile.Open(FileMode.Append, FileAccess.Write);

            byte[] bytesChange = Encoding.Default.GetBytes(string.Format("Change: {0}; {1};\n", change, DateTime.Now));
            tavlogfileStream.Write(bytesChange, 0, bytesChange.Length);

            tavlogfileStream.Close();
        }        
    }
}
