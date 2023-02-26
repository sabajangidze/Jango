using Admin.API.Filters;
using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.CustomersAggregate.Queries;
using Admin.Application.Models;
using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IDapperRepository _repo;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(ISender sender, IDapperRepository dapperRepository, IUnitOfWork unitOfWork)
    {
        _sender = sender;
        _repo = dapperRepository;
        _unitOfWork = unitOfWork;   
    }

    [HttpPost]
    //[ServiceFilter(typeof(UnitOfWorkFilterAttribute))]
    public async Task<ActionResult> CreateCustomer([FromBody]AddCustomerCommand customer)
    {
        //var result = await _sender.Send(customer);
        Customer customerEntity = new Customer
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            City = customer.City,
            Phone = customer.Phone,
            Street = customer.Steet
        };

        _unitOfWork.Add(customerEntity);
        _unitOfWork.Commit();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetCustomers()
    {
        //var result = await _sender.Send(new GetCustomersQuery());

        var customers = await _repo.Query<CustomerDTO>("Customers");

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCustomerById(Guid id)
    {
        var customer = await _repo.GetById<CustomerDTO>("Customers", id);

        return Ok(customer);
    }
}
