namespace LearningPlatform.Core.Entities;

public class Course(Guid id) : Entity<Guid>(id)
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; } = 0;

    public bool IsCompleted { get; set; } = false;

    public List<Lesson> Lessons { get; set; } = [];
}