using Admin.Application.Models;
using Admin.Domain.Abstractions;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerByIdHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.GetById<CustomerDTO>("Customers", request.Id);

        return customer;
    }
}
