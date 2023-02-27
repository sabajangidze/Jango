using Admin.API.Filters;
using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.CustomersAggregate.Queries;
using Admin.Application.Models;
using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerController(ISender sender, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
        _unitOfWork = unitOfWork;   
    }

    [HttpPost]
    //[ServiceFilter(typeof(UnitOfWorkFilterAttribute))]
    public async Task<ActionResult> CreateCustomer([FromBody]AddCustomerCommand customer)
    {
        //var result = await _sender.Send(customer);
        Customer customerEntity = _mapper.Map<Customer>(customer);
        //Customer customerEntity = new Customer
        //{
        //    FirstName = customer.FirstName,
        //    LastName = customer.LastName,
        //    Email = customer.Email,
        //    City = customer.City,
        //    Phone = customer.Phone,
        //    Street = customer.Street
        //};

        _unitOfWork.Add(customerEntity);
        _unitOfWork.Commit();

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetCustomers()
    {
        //var result = await _sender.Send(new GetCustomersQuery());

        var customers = await _unitOfWork.Query<CustomerDTO>("Customers");

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCustomerById(Guid id)
    {
        var customer = await _unitOfWork.GetById<CustomerDTO>("Customers", id);

        return Ok(customer);
    }
}
