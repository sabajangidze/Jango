using Admin.Application.EmployeeAggregate.Commands;
using Admin.Domain.Entities;
using AutoMapper;

namespace Admin.Application.Utils.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeCommand, Employee>();
    }
}
