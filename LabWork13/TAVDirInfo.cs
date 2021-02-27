using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_SEM3_LAB13
{
    class TAVDirInfo
    {
        private string dirPath;
        public TAVDirInfo(string dirPath)
        {
            this.dirPath = dirPath;
        }

        public void outDirInfo()
        {
            DirectoryInfo info = new DirectoryInfo(dirPath);

            Console.WriteLine(
                string.Format(
                    "File count: {0}\n\t" +
                    "Creation time: {1}\n\t" +
                    "Subdirectoties count: {2}",
                    info.GetFiles().Length, info.CreationTime, info.GetDirectories().Length
                ));

            Console.WriteLine("List of parent directories:");
            for(info = info.Parent; info.Parent != null; info = info.Parent)
                Console.WriteLine(string.Format("\t{0}", info.Name));

            TAVLog.LogChange("dir info get");
        }
    }
}
