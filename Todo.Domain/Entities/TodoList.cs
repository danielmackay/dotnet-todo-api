using Todo.Domain.Common;

namespace Todo.Domain.Entities;

public class TodoList : AuditableEntity
{
    public int TodoListId { get; set; }

    public string? Title { get; set; }

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
