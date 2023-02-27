using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.Models;
using Admin.Domain.Entities;
using AutoMapper;

namespace Admin.Application.Utils.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerProfile, Customer>();
        //CreateMap<AddCustomerCommand, Customer>()
        //    .ForMember(dest =>
        //        dest.FirstName,
        //        opt => opt.MapFrom(src => src.FirstName))
        //    .ForMember(dest =>
        //        dest.LastName,
        //        opt => opt.MapFrom(src => src.LastName))
        //    .ForMember(dest =>
        //        dest.Email,
        //        opt => opt.MapFrom(src => src.Email))
        //    .ForMember(dest =>
        //        dest.Phone,
        //        opt => opt.MapFrom(src => src.Phone))
        //    .ForMember(dest =>
        //        dest.Street,
        //        opt => opt.MapFrom(src => src.Street))
        //    .ForMember(dest =>
        //        dest.City,
        //        opt => opt.MapFrom(src => src.City))
        //    .ReverseMap();
    }
}
