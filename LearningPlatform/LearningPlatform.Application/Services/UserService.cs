using LearningPlatform.Application.Interfaces;
using LearningPlatform.Application.Interfaces.Auth;
using LearningPlatform.Core.Entities;
using LearningPlatform.Core.Interfaces.Repositories;

namespace LearningPlatform.Application.Services;
public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UserService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task Register(
        string userName,
        string email,
        string password,
        Core.Enums.Role role)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var user = new User(Guid.NewGuid())
        {
            UserName = userName,
            Email = email,
            PasswordHash = hashedPassword,
        };

        await _usersRepository.Add(user, role);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _usersRepository.GetByEmail(email);

        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception("Failed to login");
        }

        var token = _jwtProvider.Generate(user);

        return token;
    }
}