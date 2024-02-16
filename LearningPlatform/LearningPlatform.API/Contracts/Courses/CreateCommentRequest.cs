using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Courses;

public record CreateCommentRequest(
    [Required] Guid UserId,
    [Required] string Text);