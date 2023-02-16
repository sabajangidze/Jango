using Admin.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Entities
{
    public class ProductsOrders : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
