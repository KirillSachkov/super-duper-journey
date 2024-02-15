namespace LearningPlatform.Core.Models;

public class Lesson
{
	private Lesson(
		Guid id,
		Guid courseId,
		string title,
		string description,
		string videoLink,
		string lessonText)
	{
		Id = id;
		CourseId = courseId;
		Title = title;
		Description = description;
		VideoLink = videoLink;
		LessonText = lessonText;
	}

	public Guid Id { get; }

	public Guid CourseId { get; }

	public string Title { get; } = string.Empty;

	public string Description { get; } = string.Empty;

	public string VideoLink { get; } = string.Empty;

	public string LessonText { get; } = string.Empty;

	public static Lesson Create(
        Guid id,
        Guid courseId,
        string title,
        string description,
        string videoLink,
        string lessonText)
	{
		if (string.IsNullOrEmpty(title))
			throw new ArgumentException("Title cannot be null!");

		if (string.IsNullOrEmpty(description))
			throw new ArgumentException("Description cannot be null!");

		if (string.IsNullOrEmpty(videoLink))
			throw new ArgumentException("VideoLink cannot be null!");

		if(string.IsNullOrEmpty(lessonText))
			throw new ArgumentException("LessonText cannot be null!");

		return new Lesson(id, courseId, title, description, videoLink, lessonText);
	}
}