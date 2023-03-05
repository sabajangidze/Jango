using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using System.Text.Json.Serialization;
using Web.Application.CustomerServices;
using Web.Application.Models;
using Web.Domain.Entities;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly GetCustomers _service;
        private readonly AddCustomer _addSer;
        private readonly IPublisher _publisher;

        public CustomerController(AddCustomer addSer, IPublisher publisher)
        {
            //_service = service;
            _addSer = addSer;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _service.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody]CustomerDTO customer)
        {
            _publisher.Publish(JsonConvert.SerializeObject(customer), "report.order", null);
            _addSer.Add(customer);

            return Ok();
        }
    }
}
