using Admin.Application.CustomersAggregate.Queries;
using Admin.Application.Models;
using Admin.Domain.Abstractions;
using MediatR;

namespace Admin.Application.EmployeeAggregate.Queries;

public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetEmployeeHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<EmployeeDTO>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.Query<EmployeeDTO>("Employees");

        return employees;
    }
}
