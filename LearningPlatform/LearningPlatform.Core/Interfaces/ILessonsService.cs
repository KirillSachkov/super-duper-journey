using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Services;
public interface ILessonsService
{
    Task CreateLesson(Lesson lesson);
    Task DeleteLesson(Guid id);
    Task<Lesson> GetLessonById(Guid id);
    Task<List<Lesson>> GetLessons(Guid courseId);
    Task UpdateLesson(Guid id, string title, string description, string videoLink, string lessonText);
}