namespace LearningPlatform.Core.Entities;

public class Role(int id) : Entity<int>(id)
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Permission> Permissions { get; set; } = [];

    public ICollection<User> Users { get; set; } = [];
}