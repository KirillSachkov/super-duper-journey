using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Persistence;
public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ILessonsRepository, LessonsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }
}
