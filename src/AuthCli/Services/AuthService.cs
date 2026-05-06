using System.Net.Http.Json;
using AuthCli.Models;

namespace AuthCli.Services;

public class AuthService
{
    public static async Task TryLogin(DataAcessModel loginRequest)
    {
        var userAuthentication = await AuthenticateUser(loginRequest);

        if (userAuthentication)
        {
            //
        }
    }

    public static async Task<bool> AuthenticateUser(DataAcessModel payload)
    {
        using var client = new HttpClient();

        string usersApi = "https://minha-api.com/users/search";

        var response = await client.PostAsJsonAsync(usersApi, payload);

        return response.IsSuccessStatusCode;
    }
}
