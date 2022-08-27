using MediatR;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int TodoItemId) : IRequest;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems.FindAsync(new object[] { request.TodoItemId }, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(TodoItem), request.TodoItemId);

        _context.TodoItems.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
