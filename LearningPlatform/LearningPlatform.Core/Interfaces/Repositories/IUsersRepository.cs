using LearningPlatform.Core.Models;

namespace LearningPlatform.Core.Interfaces.Repositories;
public interface IUsersRepository
{
    Task Add(User user);
    Task<User> GetByEmail(string email);
    Task<HashSet<Enums.Permission>> GetUserPermissions(Guid userId);
}