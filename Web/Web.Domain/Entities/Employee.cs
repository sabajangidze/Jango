using Web.Domain.Abstractions;

namespace Web.Domain.Entities;

public class Employee : IEntity<Guid>, IEntityAudit
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Position { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime BirthDate { get; set; }

    public decimal Salary { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
