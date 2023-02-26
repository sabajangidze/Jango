using Admin.Application.Models;
using Admin.Domain.Abstractions;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
{
    private readonly IDapperRepository _dapperRepo;

    public GetCustomerByIdHandler(IDapperRepository dapperRepo) => _dapperRepo = dapperRepo;

    public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dapperRepo.GetById<CustomerDTO>("Customers", request.Id);

        return customer;
    }
}
