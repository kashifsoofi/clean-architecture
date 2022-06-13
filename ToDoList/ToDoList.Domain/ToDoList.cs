namespace ToDoList.Domain;

public class ToDoList
{
    public Guid Id { get; set; }
    private List<Task> tasks;

    public IEnumerable<Task> Tasks => tasks.AsReadOnly();

    public ToDoList()
    {
        Id = Guid.NewGuid();
        tasks = new List<Task>();
    }

    public ToDoList(Guid id, IEnumerable<Task> tasks)
    {
        Id = id;
        this.tasks = tasks.ToList();
    }

    public Guid AddTask(string description, DateTime dueAt)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException(nameof(description), nameof(description));
        }

        if (dueAt < DateTime.UtcNow)
        {
            throw new ArgumentException(nameof(dueAt), nameof(dueAt));
        }

        var task = new Task(
            Guid.NewGuid(),
            description,
            DateTime.UtcNow,
            DateTime.UtcNow,
            dueAt,
            false);
        tasks.Add(task);
        return task.Id;
    }

    public void DeleteTask(Guid taskId)
    {
        var foundTask = tasks.FirstOrDefault(x => x.Id == taskId);
        if (foundTask != null)
        {
            tasks.Remove(foundTask);
        }
    }

    public void CompleteTask(Guid taskId)
    {
        var foundTask = tasks.FirstOrDefault(x => x.Id == taskId);
        if (foundTask != null)
        {
            var updatedTask = new Task(
                foundTask.Id,
                foundTask.Description,
                foundTask.CreatedAt,
                DateTime.UtcNow,
                foundTask.DueAt,
                true);
            tasks.Remove(foundTask);
            tasks.Add(updatedTask);
        }
    }
}
