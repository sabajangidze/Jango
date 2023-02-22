using Admin.Domain.Entities;

namespace Admin.Application.Models;

public class OrderDTO
{
    public DateTime OrderDate { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal Sale { get; set; }

    public ICollection<ProductDTO> Products { get; set; }
}
