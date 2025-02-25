﻿using LearningPlatform.API.Contracts.Courses;
using LearningPlatform.API.Extensions;
using LearningPlatform.Application.Services;
using LearningPlatform.Core.Models;
using Microsoft.AspNetCore.Mvc;

using Permission = LearningPlatform.Core.Enums.Permission;

namespace LearningPlatform.API.Endpoints;

public static class CoursesEndpoints
{
    public static IEndpointRouteBuilder MapCoursesEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("course");

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

        return endpoints;
    }

    private static async Task<IResult> CreateCourse(
        [FromBody] CreateCourseRequest request,
        HttpContext context,
        CoursesService coursesService)
    {
        var course = Course.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.Price);

        await coursesService.CreateCourse(course);

        return Results.Ok();
    }

    private static async Task<IResult> GetCourses(
        CoursesService coursesService, HttpContext context)
    {
        var courses = await coursesService.GetCourses();

        var response = courses
            .Select(c => new GetCourseResponse(c.Id, c.Title, c.Description, c.Price));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetCourseById(
        [FromRoute] Guid id,
        CoursesService coursesService)
    {
        var course = await coursesService.GetCourseById(id);

        var response = new GetCourseResponse(course.Id, course.Title, course.Description, course.Price);

        return Results.Ok(response);
    }

    private static async Task<IResult> UpdateCourse(
    [FromRoute] Guid id,
    [FromBody] UpdateCourseRequest request,
    CoursesService coursesService)
    {
        await coursesService.UpdateCourse(id, request.Title, request.Description, request.Price);

        return Results.Ok();
    }

    private static async Task<IResult> DeleteCourse(
        [FromRoute] Guid id,
        CoursesService coursesService)
    {
        await coursesService.DeleteCourse(id);

        return Results.Ok();
    }
}