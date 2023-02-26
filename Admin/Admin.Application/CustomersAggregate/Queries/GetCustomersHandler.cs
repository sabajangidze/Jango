using Admin.Application.Models;
using Admin.Domain.Abstractions;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDTO>>
{
    private readonly IDapperRepository _dapperRepo;

    public GetCustomersHandler(IDapperRepository dapperRepo) => _dapperRepo = dapperRepo;

    public async Task<IEnumerable<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _dapperRepo.Query<CustomerDTO>("Customers");

        return customers;
    }
}
