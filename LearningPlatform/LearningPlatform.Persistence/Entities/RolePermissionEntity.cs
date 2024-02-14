using LearningPlatform.Core.Enums;

namespace LearningPlatform.Persistence.Entities;

public class RolePermissionEntity
{
    public Role Role { get; set; }

    public Permission Permission { get; set; }
}
