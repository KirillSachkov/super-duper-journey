namespace LearningPlatform.Core.Models;

public class Role
{
    public int Id { get; }

    public Enums.Role RoleType { get; }

    public string Name { get; } = string.Empty;

    public ICollection<Permission> Permissions { get; } = [];

    public ICollection<User> Users { get; } = [];
}
