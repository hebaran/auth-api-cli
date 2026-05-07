namespace AuthApi.Models;

public record CreateUserRequest(string Email, string Username, string Password);
