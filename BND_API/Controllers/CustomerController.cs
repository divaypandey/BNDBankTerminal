using BND_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public Customer GetCustomerByID(Guid customerID)
        {
            throw new NotImplementedException();
        }

        public Customer CreateCustomer(CreateCustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
