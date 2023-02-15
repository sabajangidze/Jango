using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Abstractions
{
    public interface IEntityAudit
    {
        DateTime CreatedAt { get; set; }

        DateTime? ModifiedAt { get; set; }

        DateTime? DeletedAt { get; set; }
    }
}
