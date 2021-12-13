namespace module_creator
{
  class Menu : EasyConsole.Program
  {
    public Menu()
        : base("Foundry Helper", breadcrumbHeader: true)
    {
      AddPage(new MainPage(this));
      AddPage(new BumpPage(this));
      AddPage(new CopyPage(this));

      SetPage<MainPage>();
    }
  }


}
