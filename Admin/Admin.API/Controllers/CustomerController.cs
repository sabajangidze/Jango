using Admin.API.Filters;
using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.CustomersAggregate.Queries;
using Admin.Application.Models;
using Admin.Application.Utils.Profiles;
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

    public CustomerController(ISender sender, IMapper mapper)
    {
        _sender = sender;
    }

    [HttpPost]
    //[ServiceFilter(typeof(UnitOfWorkFilterAttribute))]
    public async Task<ActionResult> CreateCustomer([FromBody]AddCustomerCommand customer)
    {
        await _sender.Send(customer);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetCustomers()
    {
        var customers = await _sender.Send(new GetCustomersQuery());

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCustomerById(Guid id)
    {
        var customer = await _sender.Send(new GetCustomerByIdQuery(id));

        return Ok(customer);
    }
}
