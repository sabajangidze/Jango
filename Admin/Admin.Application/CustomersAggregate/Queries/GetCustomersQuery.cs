using Admin.Application.Models;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public record GetCustomersQuery() : IRequest<IEnumerable<CustomerDTO>>;
