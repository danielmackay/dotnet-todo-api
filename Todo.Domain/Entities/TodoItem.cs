using Todo.Domain.Common;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities;

public class TodoItem : AuditableEntity
{
    public int TodoId { get; set; }

    public int TodoListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public bool Done { get; set; }

    public Priority Priority { get; set; }

    public DateOnly DueDate { get; set; }

    public TodoList? List { get; set; }
}
