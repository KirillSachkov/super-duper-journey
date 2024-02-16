using LearningPlatform.Core.Entities;

namespace LearningPlatform.Persistence.Repositories;
public interface ICommentRepository
{
    Task Add(Comment comment);
    Task Delete(Guid id);
    Task<List<Comment>> Get();
    Task<Comment> GetById(Guid id);
    Task Update(Guid id, string text);
}