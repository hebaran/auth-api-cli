using System.Net.Http.Json;
using AuthCli.Models;
using AuthCli.Settings;

namespace AuthCli.Services;

public class AuthService
{
    public static async Task TryLogin(LoginDataModel loginRequest)
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
        Console.ReadKey(); // REMOVER ISSO AQUI
    }

    public static async Task<bool> AuthenticateUser(LoginDataModel payload)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(ApiSettings.BaseUrl);

        var response = await client.PostAsJsonAsync("/auth/login", payload);
        
        return response.IsSuccessStatusCode;
    }

    public static async Task<bool> CreateAccount(SignupModel signupRequest)
    {
        return true;
    }

    public static async Task<bool> QueryUsername(string username)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(ApiSettings.BaseUrl);

        var response = await client.PostAsJsonAsync("/users", username);

        return response.IsSuccessStatusCode;
    }
}
