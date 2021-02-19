using System;
using System.IO.Compression;
using System.IO;

namespace HelloApp
{
  class Program
  {
    static void Main(string[] args)
    {
      string path = @"C:\test";
      DirectoryInfo dirInfo = new DirectoryInfo(path);
      if (!dirInfo.Exists)
      {
        dirInfo.Create();
      }

      string text = Console.ReadLine();

      using (FileStream fstream = new FileStream($"{path}\\text.txt", FileMode.Create))
      {
        byte[] array = System.Text.Encoding.Default.GetBytes(text);
        fstream.Write(array, 0, array.Length);
        Console.WriteLine("Текст записан в файл");
      }
      string path1 = @"C:\testz";
      DirectoryInfo dirInfo1 = new DirectoryInfo(path1);
      if (!dirInfo1.Exists)
      {
        dirInfo1.Create();
      }
      //string path2 = @"D:\Documents";
      //using (FileStream fstream = new FileStream($"{path2}\\test.zip", FileMode.Create)) { }

      string sourceFolder = "C://test/"; // исходная папка
      string zipFile = "D://Documents//test.zip"; // сжатый файл
      string targetFolder = "C://testz"; // папка, куда распаковывается файл

      ZipFile.CreateFromDirectory(sourceFolder, zipFile);
      Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
      ZipFile.ExtractToDirectory(zipFile, targetFolder);

      Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");

      using (FileStream fstream = File.OpenRead($"{path1}\\text.txt"))
      {
        byte[] array = new byte[fstream.Length];
        fstream.Read(array, 0, array.Length);
        string textFromFile = System.Text.Encoding.Default.GetString(array);
        Console.WriteLine($"Текст из файла: {textFromFile}");
      }

      Console.WriteLine("Удалить?(y/n)(если не удалите второй раз работать не будет, пока не удалите папки test, testz и файл D:\\Documents\\test.zip ");
      string check = Console.ReadLine();
      if (check=="y")
      {
        string dirName1 = @"C:\test";
        Directory.Delete(dirName1, true);

        string dirName2 = @"C:\testz";
        Directory.Delete(dirName2, true);

        string path5 = @"D:\Documents\test.zip";
        FileInfo fileInf = new FileInfo(path5);
        if (fileInf.Exists)
        {
          fileInf.Delete();
        }
      }

      Console.ReadLine();

    }
  }
}