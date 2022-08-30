using MediatR;
using System.Text.Json.Serialization;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Extensions;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand(string Title, string Note, bool? Done, DateTime? DueDate, Priority? Priority) : IRequest
{
    [JsonIgnore]
    public int TodoItemId { get; set; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems.FindAsync(new object[] { request.TodoItemId }, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(TodoItem), request.TodoItemId);

        if (request.Title.IsNotEmpty())
            entity.Title = request.Title;

        if (request.Note.IsNotEmpty())
            entity.Note = request.Note;

        if (request.Done.HasValue)
            entity.Done = request.Done.Value;

        if (request.DueDate.HasValue)
            entity.DueDate = request.DueDate.Value;

        if (request.Priority.HasValue)
            entity.Priority = request.Priority.Value;

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
