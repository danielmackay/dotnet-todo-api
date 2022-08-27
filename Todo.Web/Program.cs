using Todo.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todo-items", () =>
{
    return new List<TodoItem>();
})
.WithName("GetTodoItems");

app.MapGet("/todo-lists", () =>
{
    return new List<TodoList>();
})
.WithName("GetTodoLists");

app.Run();