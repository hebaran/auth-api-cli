using AuthCli.Models;
using AuthCli.Services;

namespace AuthCli.UI;

public static class AuthInput
{
    public static LoginDataModel RequestLoginData()
    {
        Console.Clear();

        string usernameOrEmail = Prompt.InputText("Nome de usuário ou E-mail: ");
        string password = Prompt.InputPassword("Senha: ");

        var loginRequest = new LoginDataModel(usernameOrEmail, password);

        return loginRequest;
    }

    public static async Task<SignupModel> RequestSignupData()
    {
        string username = await AskForUsername();
        string email = await AskForEmail();
        string password = await AskForPassword();

        var signupRequest = new SignupModel(username, email, password);

        return signupRequest;
    }
    
    public static async Task<string> AskForUsername() // REFATORAR ISSO AQUI
    {
        bool usernameExists = false;

        while (true)
        {
            Console.Clear();
            Console.Write("Nome de usuário: ");
            
            int leftCursor = Console.CursorLeft;
            int topCursor = Console.CursorTop;
            
            if (usernameExists)
            {
                Console.WriteLine("\n\nNome de usuáro não disponível.");
            }

            Console.SetCursorPosition(leftCursor, topCursor);
            string username = Console.ReadLine() ?? string.Empty;

            usernameExists = await AuthService.QueryUsername(username);

            if (!usernameExists)
            {
                return username;
            }
        }
    }
    
    public static async Task<string> AskForEmail()
    {
        string email = Prompt.InputText("Digite seu e-mail: ");

        return email;
    }

    public static async Task<string> AskForPassword()
    {
        string password = Prompt.InputPassword("Senha: ");
        string confirmPassword = Prompt.InputPassword("Confirme sua senha: ");

        return password;
    }
}
