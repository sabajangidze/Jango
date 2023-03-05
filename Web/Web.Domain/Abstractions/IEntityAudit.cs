namespace Web.Domain.Abstractions;

public interface IEntityAudit
{
    DateTime CreatedAt { get; set; }

    DateTime? ModifiedAt { get; set; }

    DateTime? DeletedAt { get; set; }
}
