using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Services;
public interface ICoursesService
{
    Task CreateCourse(Course course);
    Task DeleteCourse(Guid id);
    Task<Course> GetCourseById(Guid id);
    Task<List<Course>> GetCourses();
    Task UpdateCourse(Guid id, string title, string description, decimal price);
}