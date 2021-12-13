using System;
using EasyConsole;

namespace module_creator
{
  class MainPage : MenuPage
  {
    public MainPage(EasyConsole.Program program)
        : base("Main Page", program,
              new Option("overwrite package with new content", () => program.NavigateTo<CopyPage>()),
              new Option("Bump version", () => program.NavigateTo<BumpPage>()),
              new Option("quit", () =>
              {
                Console.WriteLine("Good bye");
              })
              )
    {
    }
  }
}