namespace LearningPlatform.Core.Entities;

public class Lesson(Guid id) : Entity<Guid>(id)
{
    public Guid CourseId { get; set; }

    public Course? Course { get; set; }

    public bool IsCompleted { get; set; }

    public string LessonText { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string VideoLink { get; set; } = string.Empty;
}