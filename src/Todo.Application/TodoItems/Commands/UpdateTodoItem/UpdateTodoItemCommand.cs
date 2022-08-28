using MediatR;
using System.Text.Json.Serialization;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand( bool Done) : IRequest
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

        entity.Done = request.Done;
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
