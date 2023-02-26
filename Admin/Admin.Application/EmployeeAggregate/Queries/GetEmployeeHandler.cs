using Admin.Application.CustomersAggregate.Queries;
using Admin.Application.Models;
using Admin.Domain.Abstractions;
using MediatR;

namespace Admin.Application.EmployeeAggregate.Queries;

public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<EmployeeDTO>>
{
    private readonly IDapperRepository _dapperRepo;

    public GetEmployeeHandler(IDapperRepository dapperRepo) => _dapperRepo = dapperRepo;

    public async Task<IEnumerable<EmployeeDTO>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employees = await _dapperRepo.Query<EmployeeDTO>("Employees");

        return employees;
    }
}
