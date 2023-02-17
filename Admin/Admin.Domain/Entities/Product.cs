using Admin.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Entities
{
    public class Product : IEntity<Guid>, IEntityAudit
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public double Weight { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
