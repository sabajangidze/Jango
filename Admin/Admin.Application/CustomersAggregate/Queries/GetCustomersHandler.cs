using Admin.Application.Models;
using Admin.Domain.Abstractions;
using AutoMapper;
using MediatR;

namespace Admin.Application.CustomersAggregate.Queries;

public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.Query<CustomerDTO>("Customers");

        return customers;
    }
}
