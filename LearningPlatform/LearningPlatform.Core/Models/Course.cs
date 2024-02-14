namespace LearningPlatform.Core.Models;

public class Course
{
    private readonly List<Lesson> _lessons = [];

    private Course(
        Guid id,
        string title,
        string description,
        decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
    }

    public Guid Id { get; }

    public string Title { get; } = string.Empty;

    public string Description { get; } = string.Empty;

    public decimal Price { get; } = 0;

    public IReadOnlyList<Lesson>? Lessons => _lessons;

    public static Course Create(Guid id, string title, string description, decimal price)
    {
        if (string.IsNullOrEmpty(title)) throw new ArgumentException("Title cannot be null!");

        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description cannot be null!");

        if (price < 0) throw new ArgumentException("Price cannot be null!");

        return new Course(id, title, description, price);
    }
}