using AuthCli.Services;

namespace AuthCli.UI;

public class MainMenu
{
    public bool IsRunning { get; private set; }
    public SelectOption Option { get; private set; }
    public ConsoleKeyInfo LastKeyPressed { get; private set; }

    public MainMenu()
    {
        IsRunning = true;
        Option = new SelectOption();
        LastKeyPressed = default;
    }

    public void Show()
    {
        Console.Clear();

        var menuOptions = Option.MenuOptions;

        for (int index = 0; index < menuOptions.Length; index++)
        {
            Console.Write("\x1b[1m");
            if (index == Option.Index)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"> [{menuOptions[index]}]");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  [{menuOptions[index]}]");
            }
            Console.Write("\x1b[0m");
        }

        Console.WriteLine($"Index Atual: {Option.Index}\nTecla Pressionada: {LastKeyPressed.Key}"); // REMOVER DEPOIS (DEBUG LOG)
    }

    public int? LastUserInteraction()
    {
        LastKeyPressed = Console.ReadKey(true);

        switch (LastKeyPressed.Key)
        {
            case ConsoleKey.Enter:
                return Option.Index;
            case ConsoleKey.UpArrow:
                Option.ReduceIndex();
                break;
            case ConsoleKey.DownArrow:
                Option.IncreaseIndex();
                break;
        }

        return null;
    }

    public async Task CallToAction(int option)
    {
        switch (option)
        {
            case 0:
                var userData = AuthInput.RequestLoginData();
                await AuthService.TryLogin(userData);
                //Console.ReadLine();
                break;
            case 1:
                Console.WriteLine("Criando uma nova conta.");
                Console.ReadKey();
                break;
            case 2:
                Console.WriteLine("Saindo.");
                IsRunning = false;
                break;
        }
    }

    public class SelectOption
    {
        public string[] MenuOptions { get; private set; }
        public int Index { get; private set; }

        public SelectOption()
        {
            MenuOptions = ["Entrar", "Criar uma conta", "Sair"];
            Index = 0;
        }

        public void IncreaseIndex()
        {
            if (Index < MenuOptions.Length -1)
            {
                Index++;
            }
        }

        public void ReduceIndex()
        {
            if (Index > 0)
            {
                Index--;
            }
        }
    }
}
