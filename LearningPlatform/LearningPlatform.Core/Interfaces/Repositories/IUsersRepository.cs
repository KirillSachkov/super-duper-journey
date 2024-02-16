using LearningPlatform.Core.Entities;

namespace LearningPlatform.Core.Interfaces.Repositories;
public interface IUsersRepository
{
    Task<List<User>> Get();
    Task Add(User user, Enums.Role role);
    Task<User> GetByEmail(string email);
    Task<HashSet<Enums.Permission>> GetUserPermissions(Guid userId);
}