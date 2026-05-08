using AuthApi.Data;
using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Services;

public class UserService(UserDbContext context)
{
    public UserModel CreateUser(CreateUserRequest request)
    {
        string email = request.Email;
        string username = request.Username;
        string password = request.Password;

        var user = new UserModel(email, username, password);

        return user;
    }

    public async Task AddUserToDatabase(UserModel user)
    {
        await context.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task<UserModel?> GetUser(Guid id)
    {
        var user = await context.Users.FindAsync(id);

        return user;
    }

    public async Task<UserModel?> GetUserByRequest(LoginRequest request)
    {
        (string identifier, string password) = request;

        var user = await context.Users.FirstOrDefaultAsync(x => (x.Username == identifier || x.Email == identifier) && x.Password == password);

        return user;
    }

    public async Task<List<UserModel>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }
}
