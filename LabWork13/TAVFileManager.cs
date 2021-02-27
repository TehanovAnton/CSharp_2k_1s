using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace OOP_SEM3_LAB13
{
    class TAVFileManager
    {
        private string dirPath;
        private string fileName;
        private string drivePath;
        private string sourseDirPath;

        public TAVFileManager(string dirPath, string fileName, string drivePath)
        {
            this.dirPath = dirPath;
            this.fileName = fileName;
            this.drivePath = drivePath;
        }

        public void createDirAndFile()
        {            
            fileName = string.Format(@"{0}\{1}", dirPath, fileName);

            StreamWriter writer = new StreamWriter(fileName, true);

            writer.WriteLine("Directories:");
            foreach (var i in Directory.GetDirectories(drivePath))
                writer.WriteLine(string.Format("\t{0}", i));

            writer.WriteLine("Files:");
            foreach (var i in Directory.GetFiles(drivePath))
                writer.WriteLine(string.Format("\t{0}", i));

            writer.Close();

            File.Copy(fileName, string.Format(@"{0}\{1}", dirPath, "copy.txt"), true);
            File.Delete(fileName);
            
            TAVLog.LogChange("create dir and file");
        }
        public TAVFileManager(string sourseDirPath, string dirPath)
        {
            this.sourseDirPath = sourseDirPath;
            this.dirPath = dirPath;
        }

        public void CopyFilesFromDir()
        {
            FileInfo[] files = new DirectoryInfo(sourseDirPath).GetFiles("*.txt", SearchOption.AllDirectories);            

            Directory.CreateDirectory(dirPath);
            foreach(var i in files)
                File.Copy(i.FullName, string.Format(@"{0}\{1}", dirPath, "r" + i.Name), true);

            TAVLog.LogChange("copy file from dir");
        }
        
        public void ZipTask()
        {
            string zipName = string.Format(@"{0}\{1}", dirPath, "archive.zip");

            if (File.Exists(zipName))
            {
                File.Delete(zipName);
                ZipFile.CreateFromDirectory(sourseDirPath, zipName);
            }            
            else
                ZipFile.CreateFromDirectory(sourseDirPath, zipName);

            using (ZipArchive archive = ZipFile.OpenRead(zipName))
            {
                foreach(var file in archive.Entries)
                {
                    file.ExtractToFile(string.Format(@"{0}\{1}\{2}", dirPath, "dearchive", file.Name), true);
                }
            }

            TAVLog.LogChange("create zip");
        }
    }
}