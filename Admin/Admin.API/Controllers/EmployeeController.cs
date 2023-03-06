using Admin.Application.CustomersAggregate.Commands;
using Admin.Application.EmployeeAggregate.Commands;
using Admin.Application.EmployeeAggregate.Queries;
using Admin.Application.Models;
using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using Admin.Infrastructure.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ISender _sender;

    public EmployeeController(ISender sender, IMapper mapper)
    {
        _sender = sender;
    }

    [HttpPost]
    //[ServiceFilter(typeof(UnitOfWorkFilterAttribute))]
    public async Task<ActionResult> CreateEmployee([FromBody]AddEmployeeCommand employee)
    {
        var result = await _sender.Send(employee);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        var employess = await _sender.Send(new GetEmployeeQuery());

        return Ok(employess);
    }
}
