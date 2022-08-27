namespace Todo.Domain.Common;

public abstract class BaseAuditableEntity
{
    public DateTime Created { get; set; }

    public DateTime? LastModified { get; set; }
}