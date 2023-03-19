using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using System.Text.Json.Serialization;
using Web.API.Filters;
using Web.API.Models;
using Web.Application.Models;
using Web.Application.Services;
using Web.Domain.Entities;

//TODO აქ ფაბლიშერებს რატო არ იყენებ?
//TODO customer-ის დამატების მერე უნდა გეწეროს დაფაბლიშება
namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _customerServices;
        //private readonly IPublisher _publisher;

        public CustomerController(CustomerServices customerServices/*, IPublisher publisher*/)
        {
            _customerServices = customerServices;
            //_publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _customerServices.GetCustomers();

            return Ok(customers);
        }

        [HttpPost]
        [ServiceFilter(typeof(UnitOfWorkFilterAttribute))]
        public ActionResult AddCustomer([FromBody]AddCustomerModel customer)
        {
            //_publisher.Publish(JsonConvert.SerializeObject(customer), "report.order", null);
            var customerDTO = new CustomerDTO 
            { 
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Street = customer.Street,
                City = customer.City

            };
            _customerServices.AddCustomer(customerDTO);

            return Ok();
        }
    }
}
