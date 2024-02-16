using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.Contracts.Courses;

public record UpdateCommentRequest(
    [Required] string Text);
