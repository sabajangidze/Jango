using Admin.Application.Models;
using Admin.Domain.Abstractions;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDTO>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomersHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.Query<CustomerDTO>("Customers");

        return customers;
    }
}
