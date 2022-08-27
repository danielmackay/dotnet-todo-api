using Todo.Application.Common.Mappings;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Queries.GetTodoItems;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public int TodoItemId { get; set; }

    public int? TodoListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
