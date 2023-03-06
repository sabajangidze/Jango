using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Admin.Application.EmployeeAggregate.Commands;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = _mapper.Map<Employee>(request);

        _unitOfWork.Add<Employee>(employee);

        _unitOfWork.Commit();

        return Unit.Value;
    }
}
