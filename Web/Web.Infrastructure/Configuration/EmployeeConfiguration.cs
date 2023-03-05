using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Domain.Entities;

namespace Web.Infrastructure.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
        builder.Property(e => e.LastName).HasMaxLength(30).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(30).IsRequired();
        builder.Property(e => e.Phone).HasMaxLength(15).IsRequired();
        builder.Property(e => e.Position).HasMaxLength(30).IsRequired();
        builder.Property(e => e.Salary).HasPrecision(5, 2);
    }
}
