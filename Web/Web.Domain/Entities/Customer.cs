﻿using Web.Domain.Abstractions;

namespace Web.Domain.Entities;

public class Customer : IEntity<Guid>, IEntityAudit
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Street { get; set; }

    public string City { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}