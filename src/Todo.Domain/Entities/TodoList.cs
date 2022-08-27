using Todo.Domain.Common;

namespace Todo.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public int TodoListId { get; set; }

    public string? Title { get; set; }

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
