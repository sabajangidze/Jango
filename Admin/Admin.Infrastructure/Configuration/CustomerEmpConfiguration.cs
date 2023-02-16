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
    public class CustomerEmpConfiguration : IEntityTypeConfiguration<CustomersEmployees>
    {
        public void Configure(EntityTypeBuilder<CustomersEmployees> builder)
        {
            builder.HasOne(c => c.Employee).WithMany(c => c.CustomersEmployees).IsRequired();
            builder.HasOne(c => c.Customer).WithMany(c => c.CustomersEmployees).IsRequired();
        }
    }
}
