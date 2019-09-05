using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyDirectory
{
    public class Directory_
    {
        public event EventHandler<FileReadEventArgs> FileRead;
        
        public  void Copy(string sourceDirectoryPath, string destinationDirectoryPath,bool copySubDirectories  )
        {
            DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(sourceDirectoryPath);
            if (!sourceDirectoryInfo.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirectoryPath);
            }

            // If the destination directory doesn't exist, create it.
            if (!System.IO.Directory.Exists(destinationDirectoryPath))
            {
                System.IO.Directory.CreateDirectory(destinationDirectoryPath);
            }


            // Get the files in the directory and copy them to the new location.
            FileInfo[] sourceDirectoryFiles = sourceDirectoryInfo.GetFiles();
            foreach (FileInfo file in sourceDirectoryFiles)
            {
                
                string destinationPath = Path.Combine(destinationDirectoryPath, file.Name);

                if (FileRead != null)
                {
                    FileRead(this, new FileReadEventArgs(file.Name ,file.FullName ,destinationPath ));
                }
                //Copy file to destination and do not replace if file already exists.
                try
                {
                    file.CopyTo(destinationPath, false);
                }
                catch (IOException e)
                {
                   Console.WriteLine("File Already Exists");
                }
            }

            // If copying subdirectories, copy them and their contents to destination recursively.
            if (copySubDirectories)
            {
                //Get all sub directories.
                DirectoryInfo[] sourceSubDirectories = sourceDirectoryInfo.GetDirectories();
                foreach (DirectoryInfo subdir in sourceSubDirectories)
                {
                    string destDirPath = Path.Combine(destinationDirectoryPath, subdir.Name);
                    Copy(subdir.FullName, destDirPath, copySubDirectories );
                }
            }
        }

    }

    public class FileReadEventArgs : EventArgs
    {
        public FileReadEventArgs(string name , string source , string destination)
        {
            this.name = name;
            this.source = source;
            this.destination = destination;
        }

        public string name { get; private set; }
        public string source { get; private set; }
        public string destination { get; private set; }
    }
}
