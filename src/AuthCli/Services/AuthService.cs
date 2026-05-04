using AuthCli.Models;

namespace AuthCli.Services;

public class AuthService
{
    public static async Task<UserModel?> GetUser(string usernameOrEmailInput)
    {
        UserModel? userLogin = await context.Users.FirstOrDefault(dbUser => dbUser.Name == usernameOrEmailInput || dbUser.Email == usernameOrEmailInput);

        return userLogin;
    }

    public static bool GetPassword(UserModel user, string passwordInput)
    {
        string userPassword = user.Password;

        return userPassword == passwordInput;
    }
}
