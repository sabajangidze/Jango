using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Models;
using Web.Domain.Abstractions;
using Web.Domain.Entities;

namespace Web.Application.CustomerServices;

public class AddCustomer
{
    private readonly IGenericRepository<Customer>  _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomer(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public void Add(CustomerDTO customer)
    {
        Customer customerEnt = new Customer{
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email= customer.Email,
            Street = customer.Street,
            City = customer.City,
            Phone= customer.Phone
        };
        _repository.Add(customerEnt);
        _unitOfWork.Commit();
    }
}
