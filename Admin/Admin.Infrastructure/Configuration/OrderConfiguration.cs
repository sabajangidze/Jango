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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.UnitPrice).HasPrecision(5, 2);
            builder.Property(o => o.Sale).HasPrecision(3, 2);
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).IsRequired();
            builder.HasOne(o => o.Employee).WithMany(e => e.Orders).IsRequired();
        }
    }
}
