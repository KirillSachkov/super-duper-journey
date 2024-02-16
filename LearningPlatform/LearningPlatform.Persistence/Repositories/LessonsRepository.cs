using LearningPlatform.Core.Entities;
using LearningPlatform.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence.Repositories;

public class LessonsRepository : ILessonsRepository
{
    private readonly LearningDbContext _context;

    public LessonsRepository(LearningDbContext context)
    {
        _context = context;
    }

    public async Task Add(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Lesson>> Get(Guid courseId)
    {
        var lessonEntity = await _context.Lessons
            .AsNoTracking()
            .Where(l => l.CourseId == courseId)
            .ToListAsync();

        return lessonEntity;
    }

    public async Task<Lesson> GetById(Guid id)
    {
        var lessonEntity = await _context.Lessons
            .AsNoTracking()
            .FirstOrDefaultAsync(l => l.Id == id) ?? throw new Exception();

        return lessonEntity;
    }

    public async Task Update(
        Guid id,
        string title,
        string description,
        string videoLink,
        string lessonText)
    {
        await _context.Lessons
            .Where(l => l.Id == id)
            .ExecuteUpdateAsync(s => s
            .SetProperty(l => l.Title, title)
            .SetProperty(l => l.Description, description)
            .SetProperty(l => l.VideoLink, videoLink)
            .SetProperty(l => l.LessonText, lessonText));
    }

    public async Task Delete(Guid id)
    {
        await _context.Lessons
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();
    }
}