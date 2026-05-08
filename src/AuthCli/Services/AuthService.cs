using System.Net.Http.Json;
using AuthCli.Models;

namespace AuthCli.Services;

public class AuthService
{
    public static async Task TryLogin(DataAcessModel loginRequest)
    {
        var userAuthentication = await AuthenticateUser(loginRequest);
        Console.WriteLine($"\n{loginRequest}"); // DEBUG LOG

        if (userAuthentication)
        {
            Console.WriteLine("\nLogado com sucesso.");
            //MoveToUserPanel()
        }
        else
        {
            Console.WriteLine("\nNome de usuário/e-mail ou senha incorretos.");
        }
    }

    public static async Task<bool> AuthenticateUser(DataAcessModel payload)
    {
        using var client = new HttpClient();

        string usersApi = "http://localhost:5106/auth/login";

        var response = await client.PostAsJsonAsync(usersApi, payload);
        
        return response.IsSuccessStatusCode;
    }
}
