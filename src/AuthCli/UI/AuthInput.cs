using AuthCli.Models;

namespace AuthCli.UI;

public static class AuthInput
{
    public static DataAcessModel RequestLoginData()
    {
        Console.Clear();

        string usernameOrEmailInput = Prompt.InputText("Nome de usuário ou E-mail: ");
        string passwordInput = Prompt.InputPassword("Senha: ");

        var loginRequest = new DataAcessModel(usernameOrEmailInput, passwordInput);

        return loginRequest;
    }
}
