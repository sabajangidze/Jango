using Admin.Application.Models;
using Admin.Domain.Abstractions;
using AutoMapper;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.GetById<CustomerDTO>("Customers", request.Id);

        return customer;
    }
}
