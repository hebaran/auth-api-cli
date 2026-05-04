using System.Net.Http.Json;

namespace AuthCli.Services;

public record DataAcess(string Identifier, string Key);

public class AuthService
{
    public static async Task<HttpResponseMessage> AuthenticateUser(string usernameOrEmailInput, string passwordInput)
    {
        using var client = new HttpClient();

        var payload = new DataAcess(usernameOrEmailInput, passwordInput);
        string usersApi = "https://minha-api.com/users/search";

        var response = await client.PostAsJsonAsync(usersApi, payload);

        return response;
    }
}
