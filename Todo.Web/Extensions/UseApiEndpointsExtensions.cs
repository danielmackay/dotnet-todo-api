using MediatR;
using Todo.Application.TodoItems.Commands.CreateTodoItem;
using Todo.Application.TodoItems.Queries.GetTodoItems;
using Todo.Domain.Entities;

public static class UseApiEndpointsExtensions
{
    public static IApplicationBuilder UseApiEndpoints(this WebApplication app)
    {
        app
            .MapGet("/api/todo-items", (ISender sender) => sender.Send(new GetTodoItemsQuery()))
            .WithName("GetTodoItems");

        app
            .MapPost("/api/todo-items", (ISender sender, CreateTodoItemCommand command) => sender.Send(command))
            .WithName("CreateTodoItem");

        app.MapGet("api/todo-lists", () =>
        {
            return new List<TodoList>();
        })
        .WithName("GetTodoLists");

        return app;
    }
}