namespace AuthCli.UI;

public static class Prompt
{
    public static string Input(string message)
    {
        Console.Write(message);
        string messageResponse = Console.ReadLine() ?? string.Empty;
        
        return messageResponse;
    }
}
