namespace LearningPlatform.Core.Entities;

public class Permission(int id) : Entity<int>(id)
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Role> Roles { get; set; } = [];
}
