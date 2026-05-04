using AuthCli.Models;
using AuthCli.Services;

static string ReadWrite(string message)
{
    Console.Write(message);
    string messageResponse = Console.ReadLine() ?? "";
    
    return messageResponse;
}

Console.Clear();

string usernameOrEmailInput = ReadWrite("Nome de usuário ou E-mail: ");
string passwordInput = ReadWrite("Senha: ");

UserModel? user = await AuthService.GetUser(usernameOrEmailInput);

if (user is not null)
{
    if (AuthService.GetPassword(user, passwordInput))
    {
        //
    }
}
