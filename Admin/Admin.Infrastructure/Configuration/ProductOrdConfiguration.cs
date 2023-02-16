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
    public class ProductOrdConfiguration : IEntityTypeConfiguration<ProductsOrders>
    {
        public void Configure(EntityTypeBuilder<ProductsOrders> builder)
        {
            builder.HasOne(p => p.Product).WithMany(p => p.ProductsOrders).IsRequired();
            builder.HasOne(p => p.Order).WithMany(p => p.ProductsOrders).IsRequired();
        }
    }
}
