using Admin.Application.Models;
using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Admin.Application.CustomersAggregate.Commands;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = _mapper.Map<Customer>(request);

        _unitOfWork.Add<Customer>(customer);

        _unitOfWork.Commit();

        return Unit.Value;
    }
}
