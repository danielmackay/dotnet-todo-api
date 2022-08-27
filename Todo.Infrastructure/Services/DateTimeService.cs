using Todo.Application.Common.Interfaces;

namespace Todo.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
