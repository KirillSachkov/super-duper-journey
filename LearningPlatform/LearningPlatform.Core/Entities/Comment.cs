namespace LearningPlatform.Core.Entities;

public class Comment(Guid id) : Entity<Guid>(id)
{
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public string Text { get; set; } = string.Empty;
}
