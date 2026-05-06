using System.Security.Cryptography.X509Certificates;

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

    public int Show()
    {
        while (IsRunning)
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

            Console.WriteLine($"Index Atual: {Option.Index}\nTecla Pressionada: {LastKeyPressed.Key}");
            LastKeyPressed = Console.ReadKey(true);

            switch (LastKeyPressed.Key)
            {
                case ConsoleKey.Enter:
                    switch (Option.Index)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            IsRunning = false;
                            break;
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (Option.Index > 0)
                    {
                        Option.ReduceIndex();
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (Option.Index < 2)
                    {
                        Option.IncreaseIndex();
                    }
                    
                    break;
            }
        }

        return Option.Index;
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
            Index++;
        }

        public void ReduceIndex()
        {
            Index--;
        }
    }
}
