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

var userAuthentication = await AuthService.AuthenticateUser(usernameOrEmailInput, passwordInput);

if (userAuthentication.IsSuccessStatusCode)
{
    //
}
