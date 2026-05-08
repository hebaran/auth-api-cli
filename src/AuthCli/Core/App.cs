using AuthCli.UI;

namespace AuthCli.Core;

public class App()
{
    public MainMenu Menu { get; private set; } = new();

    public async Task Run()
    {
        while (Menu.IsRunning)
        {
            Menu.Show();

            if (Menu.LastUserInteraction() is int keyPressed)
            {
                await Menu.CallToAction(keyPressed);
            }
        }
    }
}
