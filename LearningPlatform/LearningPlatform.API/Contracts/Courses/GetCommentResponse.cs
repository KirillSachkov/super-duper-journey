namespace LearningPlatform.API.Contracts.Courses;

public record GetCommentResponse(
    Guid Id,
    Guid UserId,
    string Text);
