using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_SEM3_LAB13
{
    class TAVFileInfo
    {
        public string path;
        public TAVFileInfo(string path)
        {
            this.path = path;
        }
        public void outFileInfo()
        {
            FileInfo info = new FileInfo(path);
            Console.WriteLine(string.Format(
                "Path: {0}\n\t" +
                "Size: {1}\n\t" +
                "Extension: {2}\n\t" +
                "Name: {3}\n\t" +
                "Create date: {4}\n\t" +
                "Change date: {5}\n\t"
                ,
                 info.FullName, info.Length, info.Extension, info.Name, info.CreationTime, info.LastWriteTime));

            TAVLog.LogChange("file info get");
        }        
    }
}
