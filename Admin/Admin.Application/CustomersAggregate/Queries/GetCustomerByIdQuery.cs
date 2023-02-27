using Admin.Application.Models;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public record GetCustomerByIdQuery(
    Guid Id) : IRequest<CustomerDTO>;