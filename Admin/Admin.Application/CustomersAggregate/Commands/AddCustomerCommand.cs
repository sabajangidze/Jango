using MediatR;

namespace Admin.Application.CustomersAggregate.Commands;

public record AddCustomerCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Steet,
    string City) : IRequest<Unit>;
