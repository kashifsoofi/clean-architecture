namespace ToDoList.Domain;

public class Task
{
    public Guid Id { get; }
    public string Description { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public DateTime DueAt { get; }
    public bool Completed { get; }

    public Task(
        Guid id,
        string description,
        DateTime createdAt,
        DateTime updatedAt,
        DateTime dueAt,
        bool completed)
    {
        Id = id;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DueAt = dueAt;
        Completed = completed;
    }
}
