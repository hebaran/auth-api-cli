namespace AuthCli.UI;

public static class Prompt
{
    public static string InputText(string message)
    {
        Console.Write(message);
        return CaptureInput(false);
    }

    public static string InputPassword(string message)
    {
        Console.Write(message);
        return CaptureInput(true);
    }

    private static string CaptureInput(bool isPassword)
    {
        string input = "";
        
        while (true)
        {
            var keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input[0..^1];
                Console.Write("\b \b");
            }

            else if (!char.IsControl(keyInfo.KeyChar))
            {
                input += keyInfo.KeyChar;
                Console.Write(isPassword ? '*' : keyInfo.KeyChar);
            }
        }

        return input;
    }
}
