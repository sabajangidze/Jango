using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.OrderAggregate.Commands;
using MediatR;

namespace Admin.Application.EmployeeAggregate.Commands;

public record AddEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Position,
    DateTime HireDate,
    DateTime BirthDate,
    decimal Salary) : IRequest<Unit>;
    //IEnumerable<AddCustomerCommand> Customers,
    //IEnumerable<AddOrderCommand> Orders) : IRequest<Unit>;
