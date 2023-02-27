using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.Models;
using Admin.Domain.Entities;
using AutoMapper;

namespace Admin.Application.Utils.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<AddCustomerCommand, Customer>().ReverseMap();
    }
}
