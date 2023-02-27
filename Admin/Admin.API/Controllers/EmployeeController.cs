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

    public EmployeeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetEmployees()
    {
        return Ok();
    }
}
