using Admin.Application.ProductAggregate.Commands;
using MediatR;

namespace Admin.Application.OrderAggregate.Commands;

public record AddOrderCommand(
    string FirstName,
    string Lastname,
    string Email,
    string Phone,
    string Street,
    string City,
    IEnumerable<AddProductCommand> Products) : IRequest<Guid>;
