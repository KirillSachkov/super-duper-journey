using LearningPlatform.API.Contracts.Users;
using LearningPlatform.Application.Services;
using LearningPlatform.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("users", GetUsers);

        app.MapPost("register", Register);

        app.MapPost("login", Login);

        return app;
    }

    private static async Task<IResult> GetUsers(
        IUsersRepository usersRepository)
    {
        var users = await usersRepository.Get();

        return Results.Ok(new { Users = users.Select(u => new { u.Id, u.UserName }) });
    }

    private static async Task<IResult> Register(
        [FromBody] RegisterUserRequest request,
        UserService usersService)
    {
        await usersService.Register(
            request.UserName,
            request.Email,
            request.Password,
            request.role);

        return Results.Ok();
    }

    private static async Task<IResult> Login(
        [FromBody] LoginUserRequest request,
        UserService usersService,
        HttpContext context)
    {
        var token = await usersService.Login(request.Email, request.Password);

        context.Response.Cookies.Append("secretCookie", token);

        return Results.Ok(token);
    }
}