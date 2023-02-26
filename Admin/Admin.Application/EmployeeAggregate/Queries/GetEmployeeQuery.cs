using Admin.Application.Models;
using MediatR;

namespace Admin.Application.EmployeeAggregate.Queries;

public record GetEmployeeQuery() : IRequest<IEnumerable<EmployeeDTO>>;
