using AuthCli.Models;

namespace AuthCli.UI;

public static class AuthInput
{
    public static DataAcessModel RequestUserData()
    {
        string usernameOrEmailInput = Prompt.Input("Nome de usuário ou E-mail: ");
        string passwordInput = Prompt.Input("Senha: ");

        var loginRequest = new DataAcessModel(usernameOrEmailInput, passwordInput);

        return loginRequest;
    }
}
