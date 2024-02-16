namespace LearningPlatform.Core.Entities;
public class User(Guid id) : Entity<Guid>(id)
{
    public string UserName { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public ICollection<Role> Roles { get; set; } = [];
}
