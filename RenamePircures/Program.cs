using System;
using System.IO;

namespace RenamePircures
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo mainDirectory = new DirectoryInfo(@"Pictures");
            DirectoryInfo[] directories = mainDirectory.GetDirectories();
           
            #region Console Text
            Console.WriteLine("Found "+ directories.Length + " directories.");
            Console.WriteLine("Press an key to start the process.");
            Console.ReadKey();
            #endregion

            string newName;
            foreach (DirectoryInfo folder in directories)
            {
                newName = FormatName(folder.Name);
                FileInfo[] pictures = folder.GetFiles("*.jpg");
                int i = 1;
                foreach (FileInfo picture in pictures)
                {
                    File.Move(picture.FullName, folder.FullName + newName + i + ".jpg");
                    i++;
                }
                Directory.Move(folder.FullName, mainDirectory.FullName + newName);
            }
            Console.WriteLine("Process done, check the directory.");
            Console.ReadKey();
        }

        public static string FormatName(string folderName)
        {
            folderName = @"/" + folderName + "_";
            folderName = folderName.ToLower();
            folderName = folderName.Replace("æ", "ae");
            folderName = folderName.Replace("ø", "oe");
            folderName = folderName.Replace("å", "aa");
            return folderName;
        }
    }
}
