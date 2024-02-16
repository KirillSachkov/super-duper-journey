using LearningPlatform.Core.Entities;
using LearningPlatform.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence.Repositories;
public class UsersRepository : IUsersRepository
{
    private readonly LearningDbContext _context;

    public UsersRepository(LearningDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Get()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task Add(User user, Core.Enums.Role role)
    {
        var roleEntity = await _context.Roles
            .SingleOrDefaultAsync(r => r.Id == (int)role)
            ?? throw new InvalidOperationException();

        user.Roles = [roleEntity];

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

        return userEntity;
    }

    public async Task<HashSet<Core.Enums.Permission>> GetUserPermissions(Guid userId)
    {
        var roles = await _context.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Core.Enums.Permission)p.Id)
            .ToHashSet();
    }
}