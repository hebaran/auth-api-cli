using AuthCli.Services;
using AuthCli.UI;

var menu = new MainMenu();
menu.Show();

string usernameOrEmailInput = Prompt.Input("Nome de usuário ou E-mail: ");
string passwordInput = Prompt.Input("Senha: ");

var userAuthentication = await AuthService.AuthenticateUser(usernameOrEmailInput, passwordInput);

if (userAuthentication.IsSuccessStatusCode)
{
    //
}
