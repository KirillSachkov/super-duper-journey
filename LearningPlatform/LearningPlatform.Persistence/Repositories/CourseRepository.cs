using LearningPlatform.Core.Entities;
using LearningPlatform.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly LearningDbContext _context;

    public CourseRepository(LearningDbContext context)
    {
        _context = context;
    }

    public async Task Add(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Course>> Get()
    {
        var courseEntities = await _context.Courses
            .AsNoTracking()
            .ToListAsync();

        return courseEntities;
    }

    public async Task<Course> GetById(Guid id)
    {
        var courseEntity = await _context.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();

        return courseEntity;
    }

    public async Task Update(Guid id, string title, string description, decimal price)
    {
        await _context.Courses
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.Description, description)
                .SetProperty(c => c.Price, price));
    }

    public async Task Delete(Guid id)
    {
        await _context.Courses
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}
