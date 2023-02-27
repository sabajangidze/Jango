using Admin.Domain.Entities;

namespace Admin.Application.Models;

public class ProductDTO
{
    public string Name { get; set; }

    public decimal UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public double Weight { get; set; }

    public IEnumerable<OrderDTO> Orders { get; set; }

    public IEnumerable<SupplierDTO> Suppliers { get; set; }
}
