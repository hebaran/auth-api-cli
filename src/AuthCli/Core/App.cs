using AuthCli.UI;

namespace AuthCli.Core;

public class App()
{
    public MainMenu Menu { get; private set; } = new();

    public void Run()
    {
        while (Menu.IsRunning)
        {
            Menu.Show();

            if (Menu.LastUserInteraction() is int keyPressed)
            {
                Menu.CallToAction(keyPressed);
            }
        }
    }
}
