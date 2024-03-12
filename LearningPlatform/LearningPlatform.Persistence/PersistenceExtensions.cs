using LearningPlatform.Core.Interfaces.Repositories;
using LearningPlatform.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningPlatform.Persistence;
public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LearningDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(LearningDbContext)));
        });

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ILessonsRepository, LessonsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }
}