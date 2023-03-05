using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application.CustomerServices;
using Web.Domain.Entities;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly GetCustomers _service;
        private readonly AddCustomer _addSer;

        public CustomerController(AddCustomer addSer)
        {
           
            _addSer = addSer;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            //var result = await _sender.Send(new GetCustomersQuery());

            var customers = await _service.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody]Customer customer)
        {
            //var result = await _sender.Send(new GetCustomersQuery());

            _addSer.Add(customer);

            return Ok();
        }
    }
}
