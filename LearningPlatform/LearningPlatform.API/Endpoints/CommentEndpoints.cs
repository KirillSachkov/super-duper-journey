using LearningPlatform.API.Contracts.Courses;
using LearningPlatform.API.Extensions;
using LearningPlatform.Core.Entities;
using LearningPlatform.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

using Permission = LearningPlatform.Core.Enums.Permission;

namespace LearningPlatform.API.Endpoints;

public static class CommentEndpoints
{
    public static IEndpointRouteBuilder MapCommentsEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("comments");

        endpoints.MapPost(string.Empty, CreateComment)
            .RequirePermissions(Permission.Author, Permission.Student);

        endpoints.MapGet(string.Empty, GetComments)
            .RequirePermissions(Permission.Author, Permission.Student);

        endpoints.MapGet("{id:guid}", GetCommentById)
            .RequirePermissions(Permission.Author, Permission.Student);

        endpoints.MapPut("{id:guid}", UpdateComment)
            .RequirePermissions(Permission.Author, Permission.Student);

        endpoints.MapDelete("{id:guid}", DeleteComment)
            .RequirePermissions(Permission.Author, Permission.Student);

        return endpoints;
    }

    private static async Task<IResult> CreateComment(
        [FromBody] CreateCommentRequest request,
        ICommentRepository commentRepository)
    {
        var comment = new Comment(Guid.NewGuid())
        {
            UserId = request.UserId,
            Text = request.Text
        };

        await commentRepository.Add(comment);

        return Results.Ok();
    }

    private static async Task<IResult> GetComments(
        ICommentRepository commentRepository)
    {
        var comments = await commentRepository.Get();

        var response = comments
            .Select(c => new GetCommentResponse(c.Id, c.UserId, c.Text));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetCommentById(
        [FromRoute] Guid id,
        ICommentRepository commentRepository)
    {
        var comment = await commentRepository.GetById(id);

        var response = new GetCommentResponse(comment.Id, comment.UserId, comment.Text);

        return Results.Ok(response);
    }

    private static async Task<IResult> UpdateComment(
    [FromRoute] Guid id,
    [FromBody] UpdateCommentRequest request,
    ICommentRepository commentRepository)
    {
        await commentRepository.Update(
            id,
            request.Text);

        return Results.Ok();
    }

    private static async Task<IResult> DeleteComment(
        [FromRoute] Guid id,
        ICommentRepository commentRepository)
    {
        await commentRepository.Delete(id);

        return Results.Ok();
    }
}