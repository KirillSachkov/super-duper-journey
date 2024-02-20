using LearningPlatform.API.Contracts.Courses;
using LearningPlatform.API.Extensions;
using LearningPlatform.Core.Entities;
using LearningPlatform.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Permission = LearningPlatform.Core.Enums.Permission;

namespace LearningPlatform.API.Endpoints;

public static class CoursesEndpoints
{
    public static IEndpointRouteBuilder MapCoursesEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("courses");

        endpoints.MapPost(string.Empty, CreateCourse)
            .RequirePermissions(Permission.CreateCourse);

        endpoints.MapGet(string.Empty, GetCourses)
            .RequirePermissions(Permission.ReadCourse);

        endpoints.MapGet("{id:guid}", GetCourseById)
            .RequirePermissions(Permission.ReadCourse);

        endpoints.MapPut("{id:guid}", UpdateCourse)
            .RequirePermissions(Permission.UpdateCourse);

        endpoints.MapDelete("{id:guid}", DeleteCourse)
            .RequirePermissions(Permission.DeleteCourse);

        endpoints.MapPost("{id:guid}/complete",
            ([FromRoute] Guid id, bool complete) => Results.Ok())
            .RequirePermissions(Permission.ReadCourse);

        endpoints.MapPost("{id:guid}/subscribe",
            ([FromRoute] Guid id) => Results.Ok());

        return endpoints;
    }

    private static async Task<IResult> CreateCourse(
        [FromBody] CreateCourseRequest request,
        ICourseRepository coursesRepository)
    {
        var course = new Course(Guid.NewGuid())
        {
            Title = request.Title,
            Description = request.Description,
            Price = request.Price
        };

        await coursesRepository.Add(course);

        return Results.Ok();
    }

    private static async Task<IResult> GetCourses(ICourseRepository coursesRepository)
    {
        var courses = await coursesRepository.Get();

        var response = courses
            .Select(c => new GetCourseResponse(c.Id, c.Title, c.Description, c.Price));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetCourseById(
        [FromRoute] Guid id,
        ICourseRepository coursesRepository)
    {
        var course = await coursesRepository.GetById(id);

        var response = new GetCourseResponse(
            course.Id,
            course.Title,
            course.Description,
            course.Price);

        return Results.Ok(response);
    }

    private static async Task<IResult> UpdateCourse(
    [FromRoute] Guid id,
    [FromBody] UpdateCourseRequest request,
    ICourseRepository coursesRepository)
    {
        await coursesRepository.Update(
            id,
            request.Title,
            request.Description,
            request.Price);

        return Results.Ok();
    }

    private static async Task<IResult> DeleteCourse(
        [FromRoute] Guid id,
        ICourseRepository coursesRepository)
    {
        await coursesRepository.Delete(id);

        return Results.Ok();
    }
}