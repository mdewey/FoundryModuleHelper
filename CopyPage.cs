using System;
using System.IO;
using System.Linq;
using EasyConsole;

namespace module_creator
{
  public class CopyPage : Page
  {
    public CopyPage(EasyConsole.Program program)
             : base("Page 2", program)
    {
    }


    private void CopyDirectories(string[] fileEntries, string toDirectory, string fromDirectory)
    {
      foreach (string fileName in fileEntries)
      {
        var target = $@"{toDirectory}{fileName.Replace(fromDirectory, "")}";
        var directories = target.Split(@"\");
        var marker = 0;
        var currentDirectory = directories[marker];
        foreach (var dir in directories.Skip(1))
        {
          if (dir.Contains("."))
          {
            break;
          }
          marker++;
          currentDirectory += $@"\{dir}";
          if (!Directory.Exists(currentDirectory))
          {
            Console.WriteLine($"{currentDirectory} Doesn't exists, create it");
            Directory.CreateDirectory(currentDirectory);
          }
        }
        try
        {
          File.Copy(fileName, target, true);
        }
        catch (System.Exception)
        {
          Console.WriteLine($"{target} already exists");

        }

      }
    }


    private void CopyAssets(string fromDirectory, string toDirectory)
    {
      // get all assets
      var from = fromDirectory + @"\assets";

      string[] fileEntries = Directory.GetFiles(from, "*.*", SearchOption.AllDirectories);
      Console.WriteLine($"Copying {fileEntries.Length} assets");

      this.CopyDirectories(fileEntries, toDirectory, fromDirectory);
    }

    private void CopyPacks(string fromDirectory, string toDirectory)
    {
      // get all assets
      var from = fromDirectory + @"\packs";

      string[] fileEntries = Directory.GetFiles(from, "*.*", SearchOption.AllDirectories);
      Console.WriteLine($"Copying {fileEntries.Length} packs");
      this.CopyDirectories(fileEntries, toDirectory, fromDirectory);

    }
    public override void Display()
    {
      base.Display();

      Output.WriteLine("Copying from module to repo...");

      var fromDirectory = @$"C:\Users\markt\AppData\Local\FoundryVTT\Data\modules\dewseph-rise-of-the-runelords";
      var toDirectory = $@"C:\Users\markt\foundry\dewseph-rise-of-the-runelords";

      this.CopyAssets(fromDirectory, toDirectory);

      this.CopyPacks(fromDirectory, toDirectory);
      Output.WriteLine("Do the thing!");
      Output.WriteLine("********************");
      Input.ReadString("Press [Enter] to navigate home");
      Program.NavigateHome();
    }
  }
}