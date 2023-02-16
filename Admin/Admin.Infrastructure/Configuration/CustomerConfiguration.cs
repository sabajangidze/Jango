using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Infrastructure.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(25).IsRequired();
            builder.Property(c => c.Street).HasMaxLength(25).IsRequired();
            builder.Property(c => c.City).HasMaxLength(25).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(25).IsRequired();
        }
    }
}
