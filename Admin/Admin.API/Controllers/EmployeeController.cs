using Admin.Application.Models;
using Admin.Domain.Abstractions;
using Admin.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IDapperRepository _repo;

    public EmployeeController(ISender sender, IDapperRepository dapperRepository)
    {
        _sender = sender;
        _repo = dapperRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        var employees = await _repo.Query<EmployeeDTO>("Employees");

        return Ok(employees);
    }
}
