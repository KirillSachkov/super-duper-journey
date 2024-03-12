using LearningPlatform.Core.Enums;
using LearningPlatform.Core.Interfaces.Repositories;
using LearningPlatform.Core.Interfaces.Services;

namespace LearninPlatform.Infrastructure.Authentication;

public class PermissionService : IPermissionService
{
    private readonly IUsersRepository _usersRepository;

    public PermissionService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
    {
        return _usersRepository.GetUserPermissions(userId);
    }
}