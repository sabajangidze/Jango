using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Abstractions;
using Web.Domain.Entities;

namespace Web.Application.CustomerServices;

public class GetCustomers
{
    private readonly IGenericRepository<Customer> _repository;

    public GetCustomers(IGenericRepository<Customer> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _repository.Query("Customers");
    }
}
