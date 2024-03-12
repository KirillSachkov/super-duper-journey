using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Auth;
public interface IJwtProvider
{
    string Generate(User user);
}