using LearningPlatform.Core.Enums;

namespace LearningPlatform.Core.Interfaces.Services;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
}
