using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Models;
using Todo.Application.TodoItems.Commands.CreateTodoItem;
using Todo.Application.TodoItems.Commands.DeleteTodoItem;
using Todo.Application.TodoItems.Queries.GetTodoItems;

namespace Todo.Web.Controllers;

[Route("api/todo-items")]
public class TodoItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemDto>>> GetAll([FromQuery] GetTodoItemsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await Mediator.Send(command);

    //    return NoContent();
    //}

    //[HttpPut("[action]")]
    //public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await Mediator.Send(command);

    //    return NoContent();
    //}

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));
        return NoContent();
    }
}
