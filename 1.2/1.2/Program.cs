using System;
using System.IO;

namespace _1._2
{
  class Program
  {
    static void Main(string[] args)
    {
     //------------------------------(1)
      DriveInfo[] drives = DriveInfo.GetDrives();

      foreach (DriveInfo drive in drives)
      {
        Console.WriteLine($"Название: {drive.Name}");
        Console.WriteLine($"Тип: {drive.DriveType}");
        if (drive.IsReady)
        {
          Console.WriteLine($"Объем диска: {drive.TotalSize}");
          Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
          Console.WriteLine($"Метка: {drive.VolumeLabel}");
        }
        Console.WriteLine();
      }
       //------------------------------(2)
        string path = @"C:\SomeDir2";
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      if (!dirInfo.Exists)
      {
        dirInfo.Create();
      }
      Console.WriteLine("Введите строку для записи в файл:");
      string text = Console.ReadLine();

      using (FileStream fstream = new FileStream($"{path}\\note.txt", FileMode.Create))
      {
        byte[] array = System.Text.Encoding.Default.GetBytes(text);
        fstream.Write(array, 0, array.Length);
        Console.WriteLine("Текст записан в файл");
      }

      using (FileStream fstream = File.OpenRead($"{path}\\note.txt"))
      {
        byte[] array = new byte[fstream.Length];
        fstream.Read(array, 0, array.Length);
        string textFromFile = System.Text.Encoding.Default.GetString(array);
        Console.WriteLine($"Текст из файла: {textFromFile}");
      }

      string pathq = @"C:\SomeDir2\note.txt";
      FileInfo fileInf = new FileInfo(pathq);
      if (fileInf.Exists)
      {
        fileInf.Delete();
      }

      string dirName = @"C:\SomeDir2";
      Directory.Delete(dirName, true);
      //------------------------------(3)

      //------------------------------(4)

      //------------------------------(5)

      Console.ReadLine();
    }
  }
}
