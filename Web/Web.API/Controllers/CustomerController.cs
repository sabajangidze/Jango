using Jango.IntegrationEvent;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Web.API.Models;
using Web.Application.Models;
using Web.Application.Services;
using Web.Domain.Entities;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _customerServices;
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerController(CustomerServices customerServices, IPublishEndpoint publishEndpoint)
        {
            _customerServices = customerServices;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _customerServices.GetCustomers();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody]AddCustomerModel customer)
        {
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

            CustomerEvent customerEvent = new CustomerEvent
            {
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone,
                Street = customerDTO.Street,
                City = customerDTO.City
            };

            await _publishEndpoint.Publish<CustomerEvent>(customerEvent);

            return Ok();
        }
    }
}
