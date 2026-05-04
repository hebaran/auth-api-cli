using System.Net.Http.Json;
using AuthCli.Models;

namespace AuthCli.Services;

public class AuthService
{
    public static async Task<UserModel?> GetUser(string usernameOrEmailInput)
    {
        using var client = new HttpClient();
        string usersApi = "https://minha-api.com/users/search";

        var search = new { login = usernameOrEmailInput };
        var response = await client.PostAsJsonAsync(usersApi, search);
        var userFound = await response.Content.ReadFromJsonAsync<UserModel?>();

        return userFound;
    }

    public static bool GetPassword(UserModel user, string passwordInput)
    {
        string userPassword = user.Password;

        return userPassword == passwordInput;
    }
}
