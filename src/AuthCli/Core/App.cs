using AuthCli.UI;

namespace AuthCli.Core;

public class App()
{
    public MainMenu Menu { get; private set; } = new();

    public void Run()
    {
        Menu.Show();
    }
}
