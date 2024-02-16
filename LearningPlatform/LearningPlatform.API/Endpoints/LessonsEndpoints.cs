using LearningPlatform.API.Contracts.Lessons;
using LearningPlatform.Core.Entities;
using LearningPlatform.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Endpoints;

public static class LessonsEndpoints
{
    public static IEndpointRouteBuilder MapLessonsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("lessons/{courseId:guid}", CreateLesson);

        app.MapGet("lessons/course/{courseId:guid}", GetLessons);

        app.MapGet("lessons/{id:guid}", GetLessonById);

        app.MapPut("lessons/{id:guid}", UpdateLesson);

        app.MapDelete("lessons/{id:guid}", DeleteLesson);

        return app;
    }

    private static async Task<IResult> CreateLesson(
        [FromRoute] Guid courseId,
        [FromBody] CreateLessonRequest request,
        ILessonsRepository lessonsRepository)
    {
        var lesson = new Lesson(Guid.NewGuid())
        {
            CourseId = courseId,
            Title = request.Title,
            Description = request.Description,
            VideoLink = request.VideoLink,
            LessonText = request.LessonText,
        };

        await lessonsRepository.Add(lesson);

        return Results.Ok();
    }

    private static async Task<IResult> GetLessons(
        [FromRoute] Guid courseId,
        ILessonsRepository lessonsRepository)
    {
        var lessons = await lessonsRepository.Get(courseId);

        var response = lessons
            .Select(l => new GetLessonsResponse(
                l.Id,
                l.CourseId,
                l.Title,
                l.Description,
                l.VideoLink,
                l.LessonText));

        return Results.Ok(response);
    }

    private static async Task<IResult> GetLessonById(
        [FromRoute] Guid id,
        ILessonsRepository lessonsRepository)
    {
        var lesson = await lessonsRepository.GetById(id);

        var response = new GetLessonsResponse(id, lesson.CourseId, lesson.Title, lesson.Description, lesson.VideoLink, lesson.LessonText);

        return Results.Ok(response);
    }

    private static async Task<IResult> UpdateLesson(
        [FromRoute] Guid id,
        [FromBody] UpdateLessonRequest request,
        ILessonsRepository lessonsRepository)
    {
        await lessonsRepository.Update(
            id,
            request.Title,
            request.Description,
            request.VideoLink,
            request.LessonText);

        return Results.Ok();
    }

    private static async Task<IResult> DeleteLesson(
        [FromRoute] Guid id,
        ILessonsRepository lessonsRepository)
    {
        await lessonsRepository.Delete(id);

        return Results.Ok();
    }
}