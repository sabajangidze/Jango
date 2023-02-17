using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.CompanyName).HasMaxLength(35).IsRequired();
            builder.Property(s => s.Country).HasMaxLength(25).IsRequired();
            builder.Property(s => s.City).HasMaxLength(25).IsRequired();
            builder.Property(s => s.Street).HasMaxLength(25).IsRequired();
            builder.Property(s => s.Phone).HasMaxLength(15).IsRequired();
            builder.HasMany(s => s.Products).WithMany(p => p.Suppliers);
        }
    }
}
