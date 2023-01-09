using BND_Core.Models;
using BND_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet("GetCustomerByID/{customerID}")]
        public async Task<Customer> GetCustomerByID(Guid customerID)
        {
            return await _customerService.GetCustomerByID(customerID);
        }

        [HttpGet("GetCustomerByEmail/{email}")]
        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _customerService.GetCustomerByEmail(email);
        }

        [HttpPost]
        public Customer CreateCustomer(CreateCustomerRequest request)
        {
            return _customerService.CreateCustomer(request);
        }
    }
}
