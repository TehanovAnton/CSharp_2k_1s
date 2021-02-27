using System;
using System.Collections.Generic;
using System.Text;
using System.IO;    

namespace OOP_SEM3_LAB13
{
    class TAVDiskInfo
    {
        private DriveInfo[] allInfo = DriveInfo.GetDrives();
        public void outDiskInfo()
        {
            foreach (var i in allInfo)
            {
                if (i.IsReady)
                Console.WriteLine(
                    string.Format("Drive name {0}:\n\t" +
                    "Total space: {1}\n\t" +
                    "Free space: {2}\n\t" +
                    "Drive format: {3}\n\t" +
                    "Value label: {4}\n\n",
                    i.Name, i.TotalSize, i.AvailableFreeSpace, i.DriveFormat, i.VolumeLabel));
            }

            TAVLog.LogChange("disk info get");
        }                  
    }
}
