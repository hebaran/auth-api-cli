using AuthApi.Models;
using AuthApi.Services;

namespace AuthApi.Routes;

public static class AuthRoute
{
    public static void AuthRoutes(this WebApplication app)
    {
        var authRoute = app.MapGroup("/auth");

        authRoute.MapPost("/login", async(LoginRequest request, UserService userService) =>
        {
            var user = await userService.GetUserByRequest(request);
            
            return user is not null ? Results.Ok("JWT") : Results.Unauthorized();
        });
    }
}
