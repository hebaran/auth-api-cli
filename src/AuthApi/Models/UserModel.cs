namespace AuthApi.Models;

public class UserModel(string email, string username, string password)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Email { get; private set; } = email;
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
}
