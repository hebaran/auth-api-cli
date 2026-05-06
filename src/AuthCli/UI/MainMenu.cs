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

            var menuOptions = Option.GetOptions();

            for (int index = 0; index < menuOptions.Length; index++)
            {
                Console.Write("\x1b[1m");
                if (index == Option.GetIndex())
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

            Console.WriteLine($"Index Atual: {Option.GetIndex()}\nTecla Pressionada: {LastKeyPressed.Key}");
            LastKeyPressed = Console.ReadKey(true);

            switch (LastKeyPressed.Key)
            {
                case ConsoleKey.Enter:
                    switch (Option.GetIndex())
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
                    if (Option.GetIndex() > 0)
                    {
                        Option.ReduceIndex();
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (Option.GetIndex() < 2)
                    {
                        Option.IncreaseIndex();
                    }
                    
                    break;
            }
        }

        return Option.GetIndex();
    }

    public class SelectOption
    {
        private readonly string[] _menuOptions;
        private int _index;

        public SelectOption()
        {
            _menuOptions = ["Entrar", "Criar uma conta", "Sair"];
            _index = 0;
        }

        public string[] GetOptions()
        {
            return _menuOptions;
        }

        public int GetIndex()
        {
            return _index;
        }

        public void IncreaseIndex()
        {
            _index++;
        }

        public void ReduceIndex()
        {
            _index--;
        }
    }
}
