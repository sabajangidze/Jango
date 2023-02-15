using Admin.Domain.Abstractions;

namespace Admin.Domain.Entities;

public class Customer : IEntity<Guid>, IEntityAudit
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
