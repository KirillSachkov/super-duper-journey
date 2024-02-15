using LearningPlatform.Core.Enums;

namespace LearninPlatform.Infrastructure.Authentication;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
}
