using AuthApi.Filters;
using AuthApi.Models;
using AuthApi.Services;

namespace AuthApi.Routes;

public static class UserRoute
{
    public static void UserRoutes(this WebApplication app)
    {
        var usersRoute = app.MapGroup("/users");

        usersRoute.MapPost("/", async (CreateUserRequest request, UserService userService) =>
        {
            var user = userService.CreateUser(request);
            await userService.AddUserToDatabase(user);

            return Results.Created($"/users/{user.Id}", user);
        })
        .AddEndpointFilter<ValidationFilter<CreateUserRequest>>();

        usersRoute.MapGet("/", async (UserService userService) =>
        {
            var users = await userService.GetUsers();

            return Results.Ok(users);
        });

        usersRoute.MapGet("/{id:guid}", async (Guid id, UserService userService) =>
        {
            var user = await userService.GetUser(id);

            return user is not null ? Results.Ok(user) : Results.NotFound();
        });
    }
}
