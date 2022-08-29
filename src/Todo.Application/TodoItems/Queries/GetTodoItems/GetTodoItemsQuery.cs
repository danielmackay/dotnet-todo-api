using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Mappings;
using Todo.Application.Common.Models;
using Todo.Domain.Entities;

namespace Todo.Application.TodoItems.Queries.GetTodoItems;

public record GetTodoItemsQuery : IRequest<PaginatedList<TodoItemBriefDto>>
{
    //public int? TodoListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, PaginatedList<TodoItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TodoItem> query = _context.TodoItems;

        //if (request.TodoListId.HasValue)
        //    query = query.Where(x => x.TodoListId == request.TodoListId);

        return await query
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
