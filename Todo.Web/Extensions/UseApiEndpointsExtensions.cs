using MediatR;
using Todo.Application.TodoItems.Queries.GetTodoItems;
using Todo.Domain.Entities;

public static class UseApiEndpointsExtensions
{
    public static IApplicationBuilder UseApiEndpoints(this WebApplication app)
    {
        app.MapGet("/todo-items", (ISender sender) => 
        {
            return sender.Send(new GetTodoItemsQuery());
        })
        .WithName("GetTodoItems");

        app.MapGet("/todo-lists", () =>
        {
            return new List<TodoList>();
        })
        .WithName("GetTodoLists");

        return app;
    }
}