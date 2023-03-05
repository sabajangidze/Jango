using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public void Add(Customer customer)
    {
        _repository.Add(customer);
        _unitOfWork.Commit();
    }
}
