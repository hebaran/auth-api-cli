using System.Net.Http.Json;
using AuthCli.Models;
using AuthCli.UI;

namespace AuthCli.Services;

public class AuthService // REVISITAR ISSO AQUI
{
    public static async Task RequestUserData()
    {
        string usernameOrEmailInput = Prompt.Input("Nome de usuário ou E-mail: ");
        string passwordInput = Prompt.Input("Senha: ");

        var userAuthentication = await AuthenticateUser(usernameOrEmailInput, passwordInput);

        if (userAuthentication.IsSuccessStatusCode)
        {
            //
        }
    }

    public static async Task<HttpResponseMessage> AuthenticateUser(string usernameOrEmailInput, string passwordInput)
    {
        using var client = new HttpClient();

        var payload = new DataAcessModel(usernameOrEmailInput, passwordInput);
        string usersApi = "https://minha-api.com/users/search";

        var response = await client.PostAsJsonAsync(usersApi, payload);

        return response;
    }
}
