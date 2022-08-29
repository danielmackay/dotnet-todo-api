using Todo.Application.Common.Mappings;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.TodoItems.Queries.GetTodoItems;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public int TodoItemId { get; set; }

    //public int? TodoListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public bool Done { get; set; }

    public Priority Priority { get; set; }

    public DateTime? DueDate { get; set; }
}
