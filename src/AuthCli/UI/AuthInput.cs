using AuthCli.Models;

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

}
