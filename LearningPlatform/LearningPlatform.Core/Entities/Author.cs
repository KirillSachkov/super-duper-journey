namespace LearningPlatform.Core.Entities;

public class Author(Guid id) : Entity<Guid>(id)
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public ICollection<Course> Courses { get; set; } = [];
}