using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Models;
using Todo.Application.TodoItems.Commands.CreateTodoItem;
using Todo.Application.TodoItems.Commands.DeleteTodoItem;
using Todo.Application.TodoItems.Commands.UpdateTodoItem;
using Todo.Application.TodoItems.Queries.GetTodoItem;
using Todo.Application.TodoItems.Queries.GetTodoItems;

namespace Todo.Web.Controllers;

[Route("api/todo-items")]
public class TodoItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetAll([FromQuery] GetTodoItemsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{todoItemId:int}")]
    public async Task<ActionResult<TodoItemDto>> Get(int todoItemId)
    {
        return await Mediator.Send(new GetTodoItemQuery(todoItemId));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPatch("{todoItemId:int}")]
    public async Task<ActionResult> Update(int todoItemId, UpdateTodoItemCommand command)
    {
        command.TodoItemId = todoItemId;
        await Mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete("{todoItemId:int}")]
    public async Task<ActionResult> Delete(int todoItemId)
    {
        await Mediator.Send(new DeleteTodoItemCommand(todoItemId));
        return NoContent();
    }

}
