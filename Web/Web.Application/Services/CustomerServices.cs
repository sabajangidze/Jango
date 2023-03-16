using System.Web.Razor.Parser.SyntaxTree;
using Web.Application.Models;
using Web.Domain.Abstractions;
using Web.Domain.Entities;

namespace Web.Application.Services;

public class CustomerServices
{
    private readonly IGenericRepository<Customer> _repo;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerServices(IGenericRepository<Customer> repo, IUnitOfWork unitOfWork)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
    }

    public void AddCustomer(CustomerDTO customer)
    {
        Customer customerEntity = new Customer
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            Street = customer.Street,
            City = customer.City
        };

        _repo.Add(customerEntity);
        _unitOfWork.Commit();
    }

    public async Task<IEnumerable<CustomerDTO>> GetCustomers()
    {
        var customers = await _repo.Query("Customers");

        var customerDTOs = customers.Select(customer => new CustomerDTO
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            Street = customer.Street,
            City = customer.City
        });

        return customerDTOs.ToList();
    }

    public async Task<CustomerDTO> GetCustomer(Guid id)
    {
        var customer = await _repo.GetByIdAsync("Customers", id);

        CustomerDTO customerDTO = new CustomerDTO
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            Street = customer.Street,
            City = customer.City
        };

        return customerDTO;
    }
}
