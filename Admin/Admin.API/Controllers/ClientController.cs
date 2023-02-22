using Admin.API.Filters;
using Admin.Application.CustomersAggregate.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Admin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly ISender _sender;

    public ClientController(ISender sender) => _sender = sender;

    [HttpPost]
    //[ServiceFilter(typeof(UnitOfWorkFilterAttribute))]
    public async Task<ActionResult> CreateCustomer([FromBody]AddCustomerCommand customer)
    {
        var result = await _sender.Send(customer);

        return Ok(result);
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Hello");
    }
}
