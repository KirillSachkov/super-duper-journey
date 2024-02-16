using LearningPlatform.Core.Entities;

namespace LearningPlatform.Application.Interfaces.Auth;
public interface IJwtProvider
{
    string Generate(User user);
}