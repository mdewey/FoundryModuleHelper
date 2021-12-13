using EasyConsole;

namespace module_creator
{
  public class BumpPage : Page
  {
    public BumpPage(EasyConsole.Program program)
             : base("Page 2", program)
    {
    }

    public override void Display()
    {
      base.Display();

      Output.WriteLine("Hello from being bumped");

      Input.ReadString("Press [Enter] to navigate home");
      Program.NavigateHome();
    }
  }
}