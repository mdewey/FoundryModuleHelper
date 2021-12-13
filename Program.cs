using System.Threading.Tasks;

namespace module_creator
{
  class Program
  {


    static Task Main(string[] args)
    {
      // var menu = new EasyConsole.Menu()
      //   .Add("overwrite package with new content", () => Console.WriteLine("foo selected"))
      //   .Add("bump version - patch", () => Console.WriteLine("bar selected"))
      //   .Add("bump version - minor", () => Console.WriteLine("bar selected"))
      //   .Add("bump version - major", () => Console.WriteLine("bar selected"))
      //   .Add("publish to github", () => Console.WriteLine("bar selected"));

      // menu.Display();
      new Menu().Run();
      return Task.CompletedTask;
    }
  }
}
