using LearningPlatform.Core.Enums;

namespace LearningPlatform.Persistence;

public class PermissionEntity
{
    public Permission Permission { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<RoleEntity> Roles { get; set; } = [];
}
