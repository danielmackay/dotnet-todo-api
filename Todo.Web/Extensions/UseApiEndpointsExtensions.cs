using MediatR;
using Todo.Application.TodoItems.Commands.CreateTodoItem;
using Todo.Application.TodoItems.Commands.DeleteTodoItem;
using Todo.Application.TodoItems.Queries.GetTodoItems;
using Todo.Domain.Entities;

namespace Todo.Web.Extensions;

public static class UseApiEndpointsExtensions
{
    public static IApplicationBuilder UseApiEndpoints(this WebApplication app)
    {
        app
            .MapGet("/api/todo-items", async (ISender sender) => await sender.Send(new GetTodoItemsQuery()))
            .WithName("GetTodoItems");

        app
            .MapPost("/api/todo-items", async (ISender sender, CreateTodoItemCommand command) => await sender.Send(command))
            .WithName("CreateTodoItem");

        app
            .MapDelete("/api/todo-items/{todoItemId}", async (ISender sender, int todoItemId) =>
            {
                await sender.Send(new DeleteTodoItemCommand(todoItemId));
                return Results.NoContent();
            })
            .WithName("DeleteTodoItem");

        app
            .MapGet("api/todo-lists", () =>
            {
                return new List<TodoList>();
            })
            .WithName("GetTodoLists");

        return app;
    }
}