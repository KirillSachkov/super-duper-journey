using LearningPlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Persistence.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly LearningDbContext _context;

    public CommentRepository(LearningDbContext context)
    {
        _context = context;
    }

    public async Task Add(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Comment>> Get()
    {
        return await _context.Comments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Comment> GetById(Guid id)
    {
        return await _context.Comments
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();
    }

    public async Task Update(Guid id, string text)
    {
        await _context.Comments
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Text, text));
    }

    public async Task Delete(Guid id)
    {
        await _context.Comments
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}