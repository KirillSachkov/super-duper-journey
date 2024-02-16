using LearningPlatform.Core.Entities;

namespace LearningPlatform.Core.Interfaces.Repositories;
public interface ILessonsRepository
{
    Task Add(Lesson lesson);
    Task Delete(Guid id);
    Task<List<Lesson>> Get(Guid courseId);
    Task<Lesson> GetById(Guid id);
    Task Update(Guid id, string title, string description, string videoLink, string lessonText);
}