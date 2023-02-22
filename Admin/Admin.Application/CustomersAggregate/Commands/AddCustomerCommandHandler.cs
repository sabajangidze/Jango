using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using MediatR;

namespace Admin.Application.CustomersAggregate.Commands;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomerCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = new Customer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        _unitOfWork.Add<Customer>(customer);

        _unitOfWork.Commit();

        return Unit.Value;
    }
}
