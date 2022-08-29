using AutoMapper;
using MediatR;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Interfaces;
using Todo.Application.TodoItems.Queries.GetTodoItems;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Queries.GetTodoItem;

public record GetTodoItemQuery(int TodoItemId) : IRequest<TodoItemDto>;

public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItemDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodoItemDto> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems.FindAsync(new object[] { request.TodoItemId }, cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(TodoItem), request.TodoItemId);

        return _mapper.Map<TodoItemDto>(entity);
    }
}
