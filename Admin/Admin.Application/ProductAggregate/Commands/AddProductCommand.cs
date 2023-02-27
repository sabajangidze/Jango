using Admin.Application.OrderAggregate.Commands;
using Admin.Application.SupplierAggregate.Commands;
using MediatR;

namespace Admin.Application.ProductAggregate.Commands;

public record AddProductCommand(
    string Name,
    decimal UnitPrice,
    int UnitsInStock,
    double Weight,
    IEnumerable<AddOrderCommand> Orders,
    IEnumerable<AddSupplierCommand> Suppliers) : IRequest<Unit>;
