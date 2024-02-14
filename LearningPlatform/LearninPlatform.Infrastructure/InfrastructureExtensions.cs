using LearningPlatform.Application.Interfaces.Auth;
using LearninPlatform.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Persistence;
public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
