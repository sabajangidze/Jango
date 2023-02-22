using Admin.Domain.Entities;

namespace Admin.Application.Models;

public class SupplierDTO
{
    public string CompanyName { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Phone { get; set; }

    public ICollection<ProductDTO> Products { get; set; }
}
