using BND_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BND_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        public BankAccount CreateBankAccountForCustomer(CreateBankAccountRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
