using System.Net.Http.Json;
using AuthCli.Models;

namespace AuthCli.Services;

public class AuthService
{
    public static async Task<HttpResponseMessage> AuthenticateUser(string usernameOrEmailInput, string passwordInput)
    {
        using var client = new HttpClient();

        var payload = new DataAcessModel(usernameOrEmailInput, passwordInput);
        string usersApi = "https://minha-api.com/users/search";

        var response = await client.PostAsJsonAsync(usersApi, payload);

        return response;
    }
}
