using LearningPlatform.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Application;
public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<UserService>();

        return services;
    }
}
