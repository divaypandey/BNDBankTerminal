using BND_API.Models;
using BND_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<Customer> GetCustomerByID(Guid customerID)
        {
            return await _customerService.GetCustomerByID(customerID);
        }

        [HttpGet]
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
